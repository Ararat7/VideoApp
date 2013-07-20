using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VideoApp
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        private void InsertVideo(Video video)
        {
            string folderPath = Path.ChangeExtension(video.Path, null);
            int orderingNumber = 0;

            try
            {
                conn.Open();

                if (GridView1.Rows.Count != 0)
                {
                    SqlCommand maxOrder = new SqlCommand();
                    maxOrder.Connection = conn;
                    maxOrder.CommandText = "SELECT MAX([Ordering]) FROM Videos";
                    maxOrder.CommandType = CommandType.Text;
                    orderingNumber = (int)maxOrder.ExecuteScalar() + 1;
                }

                SqlCommand insert = new SqlCommand("InsertVideo", conn);
                insert.CommandType = CommandType.StoredProcedure;

                insert.Parameters.AddWithValue("@Ordering", orderingNumber);
                insert.Parameters.AddWithValue("@Name", video.Name);
                insert.Parameters.AddWithValue("@Path", folderPath);
                insert.Parameters.AddWithValue("@Text1", video.Text1);
                insert.Parameters.AddWithValue("@Text2", video.Text2);
                insert.Parameters.AddWithValue("@Details", video.Details);
                insert.Parameters.AddWithValue("@Link1", video.Link1);
                insert.Parameters.AddWithValue("@Link2", video.Link2);
                insert.Parameters.AddWithValue("@Facebook", video.Facebook);
                insert.Parameters.AddWithValue("@Twitter", video.Twitter);
                insert.Parameters.AddWithValue("@AppStore", video.AppStore);
                insert.Parameters.AddWithValue("@GooglePlay", video.GooglePlay);
                insert.Parameters.AddWithValue("@Maps", video.Maps);

                int ok = insert.ExecuteNonQuery();
                if (ok > 0)
                {

                    FileUploadControl.SaveAs(Server.MapPath(video.Path));
                    Server.MapPath(video.Path).SplitVideoIntoImages();
                    
                    File.Delete(Server.MapPath(video.Path)); // After Spliting into images video is deleted

                    GridView1.DataBind();
                    //MessageBox.Show("Data Added.");
                }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile && (Text1.Value != string.Empty))
            {
                Video video = new Video();
                string fileName = Path.Combine("~/Videos/", FileUploadControl.FileName);
                fileName = string.Format("{0}", fileName.Replace("%", @"_"));

                video.Name = Text1.Value;
                video.Path = fileName;
                video.Text1 = TextArea2.Value;
                video.Text2 = TextArea1.Value;
                video.Details = TextArea3.Value;
                video.Link1 = Text2.Value;
                video.Link2 = Text7.Value;
                video.Facebook = facebookTextBox.Value;
                video.Twitter = twitterTextBox.Value;
                video.AppStore = appstoreTextBox.Value;
                video.GooglePlay = googleplayTextBox.Value;
                video.Maps = mapsTextBox.Value;

                
                InsertVideo(video);
            }
        }

        private void RemoveVideo(int id)
        {
            //string filePath = GridView1.SelectedRow.Cells[3].Text;
            string filePath = string.Format("{0}", GridView1.SelectedRow.Cells[4].Text.Replace("&#39;", @"'").Replace("&amp;", @"&"));

            if (Directory.Exists(Server.MapPath(filePath)))
            {
                Directory.Delete(Server.MapPath(filePath), true);
            }

            try
            {
                conn.Open();

                SqlCommand delete = new SqlCommand("DeleteVideo", conn);
                delete.CommandType = CommandType.StoredProcedure;

                delete.Parameters.AddWithValue("@Original_Id", id);

                int ok = delete.ExecuteNonQuery();
                if (ok > 0)
                {
                    GridView1.DataBind();
                    //MessageBox.Show("Data Deleted.");
                }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != null)
            {
                int id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                RemoveVideo(id);
            }
            Text6.Value = string.Empty;
            Text1.Value = string.Empty;
            TextArea2.Value = string.Empty;
            TextArea1.Value = string.Empty;
            TextArea3.Value = string.Empty;
            Text2.Value = string.Empty;
            Text7.Value = string.Empty;
            facebookTextBox.Value = string.Empty;
            twitterTextBox.Value = string.Empty;
            appstoreTextBox.Value = string.Empty;
            googleplayTextBox.Value = string.Empty;
            mapsTextBox.Value = string.Empty;
        }

        private void UpdateVideo(int id, Video video)
        {

            string oldFilePath = GridView1.SelectedRow.Cells[4].Text;
            string newVideoFolderPath = oldFilePath;

            if (FileUploadControl.HasFile)
            {
                newVideoFolderPath = Path.ChangeExtension(video.Path, null);

                if (File.Exists(Server.MapPath(oldFilePath)))
                {
                    File.Delete(Server.MapPath(oldFilePath));
                }
                if (Directory.Exists(Server.MapPath(oldFilePath)))
                {
                    Directory.Delete(Server.MapPath(oldFilePath), true);
                }
            }

            try
            {
                conn.Open();

                SqlCommand update = new SqlCommand("UpdateVideo", conn);
                update.CommandType = CommandType.StoredProcedure;

                update.Parameters.AddWithValue("@Id", id);
                update.Parameters.AddWithValue("@Name", video.Name);
                update.Parameters.AddWithValue("@Path", newVideoFolderPath);
                update.Parameters.AddWithValue("@Text1", video.Text1);
                update.Parameters.AddWithValue("@Text2", video.Text2);
                update.Parameters.AddWithValue("@Details", video.Details);
                update.Parameters.AddWithValue("@Link1", video.Link1);
                update.Parameters.AddWithValue("@Link2", video.Link2);
                update.Parameters.AddWithValue("@Facebook", video.Facebook);
                update.Parameters.AddWithValue("@Twitter", video.Twitter);
                update.Parameters.AddWithValue("@AppStore", video.AppStore);
                update.Parameters.AddWithValue("@GooglePlay", video.GooglePlay);
                update.Parameters.AddWithValue("@Maps", video.Maps);

                int ok = update.ExecuteNonQuery();
                if (ok > 0)
                {
                    if (FileUploadControl.HasFile)
                    {
                        FileUploadControl.SaveAs(Server.MapPath(video.Path));
                        Server.MapPath(video.Path).SplitVideoIntoImages();

                        File.Delete(Server.MapPath(video.Path)); // After Spliting into images video is deleted
                    }

                    GridView1.DataBind();
                    //MessageBox.Show("Data Updated.");
                }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if ((Text1.Value != string.Empty) && (GridView1.Rows.Count > 0) && (GridView1.SelectedRow != null))
            {
                string fileName = string.Empty;

                if (FileUploadControl.HasFile)
                {
                    fileName = Path.Combine("~/Videos/", FileUploadControl.FileName);
                    fileName = string.Format("{0}", fileName.Replace("%", @"_"));
                }

                int id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);

                Video video = new Video();

                video.Name = Text1.Value;
                video.Path = fileName;
                video.Text1 = TextArea2.Value;
                video.Text2 = TextArea1.Value;
                video.Details = TextArea3.Value;
                video.Link1 = Text2.Value;
                video.Link2 = Text7.Value;
                video.Facebook = facebookTextBox.Value;
                video.Twitter = twitterTextBox.Value;
                video.AppStore = appstoreTextBox.Value;
                video.GooglePlay = googleplayTextBox.Value;
                video.Maps = mapsTextBox.Value;

                UpdateVideo(id, video);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Text6.Value = string.Format("{0}", GridView1.SelectedRow.Cells[1].Text.Replace("&#39;", @"'").Replace("&amp;", @"&").Replace("&nbsp;",@""));  // Id
            Text1.Value = string.Format("{0}", GridView1.SelectedRow.Cells[3].Text.Replace("&#39;", @"'").Replace("&amp;", @"&").Replace("&nbsp;", @""));  // Name
            TextArea2.Value = string.Format("{0}", GridView1.SelectedRow.Cells[5].Text.Replace("&#39;", @"'").Replace("&amp;", @"&").Replace("&nbsp;", @""));  // Text1
            TextArea1.Value = string.Format("{0}", GridView1.SelectedRow.Cells[6].Text.Replace("&#39;", @"'").Replace("&amp;", @"&").Replace("&nbsp;", @""));  // Text2
            TextArea3.Value = string.Format("{0}", GridView1.SelectedRow.Cells[7].Text.Replace("&#39;", @"'").Replace("&amp;", @"&").Replace("&nbsp;", @""));  // Details
            Text2.Value = string.Format("{0}", GridView1.SelectedRow.Cells[8].Text.Replace("&#39;", @"'").Replace("&amp;", @"&").Replace("&nbsp;", @""));  // Link1
            Text7.Value = string.Format("{0}", GridView1.SelectedRow.Cells[9].Text.Replace("&#39;", @"'").Replace("&amp;", @"&").Replace("&nbsp;", @""));  // Link2
            facebookTextBox.Value = string.Format("{0}", GridView1.SelectedRow.Cells[10].Text.Replace("&#39;", @"'").Replace("&amp;", @"&").Replace("&nbsp;", @""));
            twitterTextBox.Value = string.Format("{0}", GridView1.SelectedRow.Cells[11].Text.Replace("&#39;", @"'").Replace("&amp;", @"&").Replace("&nbsp;", @""));
            appstoreTextBox.Value = string.Format("{0}", GridView1.SelectedRow.Cells[12].Text.Replace("&#39;", @"'").Replace("&amp;", @"&").Replace("&nbsp;", @""));
            googleplayTextBox.Value = string.Format("{0}", GridView1.SelectedRow.Cells[13].Text.Replace("&#39;", @"'").Replace("&amp;", @"&").Replace("&nbsp;", @""));
            mapsTextBox.Value = string.Format("{0}", GridView1.SelectedRow.Cells[14].Text.Replace("&#39;", @"'").Replace("&amp;", @"&").Replace("&nbsp;", @""));
        }

        private void GridViewFilter()
        {
            SqlDataSource1.FilterExpression = "[Name] LIKE '%{0}%'";
            SqlDataSource1.FilterParameters.Clear();
            SqlDataSource1.FilterParameters.Add("Name", searchTextBox.Text);
            GridView1.DataBind();
        }

        protected void searchTextBox_TextChanged(object sender, EventArgs e)
        {

            GridViewFilter();
        }

        protected void moveUpButton_Click(object sender, EventArgs e)
        {
            int selRowIndex = GridView1.SelectedRow.RowIndex;
            if (selRowIndex > 0)
            {
                try
                {
                    int orderNumberToBeMovedUp;
                    int.TryParse(GridView1.Rows[selRowIndex].Cells[2].Text, out orderNumberToBeMovedUp);
                    int idToBEMovedUp;
                    int.TryParse(GridView1.Rows[selRowIndex].Cells[1].Text, out idToBEMovedUp);

                    int orderNumberToBeMovedDown;
                    int.TryParse(GridView1.Rows[selRowIndex - 1].Cells[2].Text, out orderNumberToBeMovedDown);
                    int idToBEMovedDown;
                    int.TryParse(GridView1.Rows[selRowIndex - 1].Cells[1].Text, out idToBEMovedDown);

                    conn.Open();

                    SqlCommand moveUp = new SqlCommand();
                    moveUp.Connection = conn;
                    moveUp.CommandText = "UPDATE Videos SET Ordering=@Ordering WHERE Id=@Id";
                    moveUp.CommandType = CommandType.Text;
                    moveUp.Parameters.AddWithValue(@"Ordering", orderNumberToBeMovedUp);
                    moveUp.Parameters.AddWithValue(@"Id", idToBEMovedDown);
                    moveUp.ExecuteNonQuery();

                    SqlCommand moveDown = new SqlCommand();
                    moveDown.Connection = conn;
                    moveDown.CommandText = "UPDATE Videos SET Ordering=@Ordering WHERE Id=@Id";
                    moveDown.CommandType = CommandType.Text;
                    moveDown.Parameters.AddWithValue(@"Ordering", orderNumberToBeMovedDown);
                    moveDown.Parameters.AddWithValue(@"Id", idToBEMovedUp);
                    moveDown.ExecuteNonQuery();

                    GridViewFilter();
                    GridView1.SelectedIndex--;
                }
                catch
                {
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        protected void MoveDownButton_Click(object sender, EventArgs e)
        {
            int selRowIndex = GridView1.SelectedRow.RowIndex;
            if (selRowIndex < GridView1.Rows.Count - 1)
            {
                try
                {
                    int orderNumberToBeMovedUp;
                    int.TryParse(GridView1.Rows[selRowIndex + 1].Cells[2].Text, out orderNumberToBeMovedUp);
                    int idToBEMovedUp;
                    int.TryParse(GridView1.Rows[selRowIndex + 1].Cells[1].Text, out idToBEMovedUp);

                    int orderNumberToBeMovedDown;
                    int.TryParse(GridView1.Rows[selRowIndex].Cells[2].Text, out orderNumberToBeMovedDown);
                    int idToBEMovedDown;
                    int.TryParse(GridView1.Rows[selRowIndex].Cells[1].Text, out idToBEMovedDown);

                    conn.Open();

                    SqlCommand moveUp = new SqlCommand();
                    moveUp.Connection = conn;
                    moveUp.CommandText = "UPDATE Videos SET Ordering=@Ordering WHERE Id=@Id";
                    moveUp.CommandType = CommandType.Text;
                    moveUp.Parameters.AddWithValue(@"Ordering", orderNumberToBeMovedUp);
                    moveUp.Parameters.AddWithValue(@"Id", idToBEMovedDown);
                    moveUp.ExecuteNonQuery();

                    SqlCommand moveDown = new SqlCommand();
                    moveDown.Connection = conn;
                    moveDown.CommandText = "UPDATE Videos SET Ordering=@Ordering WHERE Id=@Id";
                    moveDown.CommandType = CommandType.Text;
                    moveDown.Parameters.AddWithValue(@"Ordering", orderNumberToBeMovedDown);
                    moveDown.Parameters.AddWithValue(@"Id", idToBEMovedUp);
                    moveDown.ExecuteNonQuery();

                    GridViewFilter();
                    GridView1.SelectedIndex++;
                }
                catch
                {
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
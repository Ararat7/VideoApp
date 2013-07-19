<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="VideoApp.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="StyleSheet" type="text/css" href="Admin.css"/>

    <style type="text/css">
        .auto-style1 {
            width: 250px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <!-- upload -->
 
          <fieldset >
              <legend>Admin panel
              </legend>
          
          
        <table style="width: 100%;">
             <tr>
                  
                <td class="auto-style1">Upload video:</td>
                <td colspan="3">
                     <asp:FileUpload id="FileUploadControl" runat="server" />
                </td>
                 <td class="auto-style1">
                     Facebook:
                 </td>
                 <td>
                     <input id="facebookTextBox" type="text" class="TextBox" runat="server" />
                 </td>
                  
            </tr>
             <tr>
                <td class="auto-style1">ID:</td>
                <td colspan="3">
                    <input id="Text6" type="text" class="TextBox" readonly="readonly" runat="server" />
                </td>
                 <td class="auto-style1">
                     Twitter:
                 </td>
                 <td>
                     <input id="twitterTextBox" type="text" class="TextBox" runat="server" />
                 </td>
            </tr>
            <tr>
                <td class="auto-style1">Name:</td>
                <td>
                    <input id="Text1" type="text" class="TextBox" runat="server" />
                </td>
                <td class="auto-style1">Details:</td>
                <td>
                    <textarea id="TextArea3" name="S1" rows="2" class="TextArea" runat="server"></textarea></td>
                <td class="auto-style1">
                     AppStore:
                 </td>
                 <td>
                     <input id="appstoreTextBox" type="text" class="TextBox" runat="server" />
                 </td>
            </tr>
           <tr>
                <td class="auto-style1">Text1:</td>
                <td>
                    <textarea id="TextArea2" name="S2" class="TextArea" runat="server"></textarea>
                </td>
               <td class="auto-style1">Link1:</td>
                <td>
                    <input id="Text2" type="text" class="TextBox" runat="server" /></td>
               <td class="auto-style1">
                     GooglePlay:
                 </td>
                 <td>
                     <input id="googleplayTextBox" type="text" class="TextBox" runat="server" />
                 </td>
            </tr>
            <tr>
                <td class="auto-style1">Text2:</td>
                <td>
                    <textarea id="TextArea1" name="S1" rows="2" class="TextArea" runat="server"></textarea></td>
                <td class="auto-style1">Link2:</td>
                <td>
                    <input id="Text7" type="text" class="TextBox" runat="server" /></td>
                <td class="auto-style1">
                     Maps:
                 </td>
                 <td>
                     <input id="mapsTextBox" type="text" class="TextBox" runat="server" />
                 </td>
            </tr>
             <tr>
                
                <td colspan="6" class="style2" >
                    <asp:Button ID="Button1" runat="server" Text="Upload" Height="30px" Width="90px" OnClick="Button1_Click" />
                   &nbsp;<asp:Button ID="Button2" runat="server" Height="30px" Text="Update" Width="90px" OnClick="Button2_Click" />
                    &nbsp;<asp:Button ID="Button3" runat="server" Height="30px" Text="Delete" Width="90px" OnClick="Button3_Click" />
                   </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Search By Name:
                </td>
                <td colspan="5">
                    <asp:TextBox ID="searchTextBox" Width="300px" AutoPostBack="true" runat="server" OnTextChanged="searchTextBox_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Button ID="moveUpButton" runat="server" Text="Move Up" OnClick="moveUpButton_Click" />
                    <asp:Button ID="MoveDownButton" runat="server" Text="Move Down" OnClick="MoveDownButton_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Videos] ORDER BY [Ordering]" >
                    </asp:SqlDataSource>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="6" DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="#333333"
                        GridLines="None" BorderWidth="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BorderStyle="Solid">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                            <asp:BoundField DataField="Ordering" HeaderText="Ordering" SortExpression="Ordering" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Path" HeaderText="Path" SortExpression="Path" />
                            <asp:BoundField DataField="Text1" HeaderText="Text1" SortExpression="Text1" />
                            <asp:BoundField DataField="Text2" HeaderText="Text2" SortExpression="Text2" />
                            <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
                            <asp:BoundField DataField="Link1" HeaderText="Link1" SortExpression="Link1" />
                            <asp:BoundField DataField="Link2" HeaderText="Link2" SortExpression="Link2" />
                            <asp:BoundField DataField="Facebook" HeaderText="Facebook" SortExpression="Facebook" />
                            <asp:BoundField DataField="Twitter" HeaderText="Twitter" SortExpression="Twitter" />
                            <asp:BoundField DataField="AppStore" HeaderText="AppStore" SortExpression="AppStore" />
                            <asp:BoundField DataField="GooglePlay" HeaderText="GooglePlay" SortExpression="GooglePlay" />
                            <asp:BoundField DataField="Maps" HeaderText="Maps" SortExpression="Maps" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                      </asp:GridView>
                 </td>
            </tr>

             
        </table>
    
              </fieldset>

    </form>
</body>
</html>

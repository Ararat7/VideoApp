<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="VideoApp.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="StyleSheet" type="text/css" href="Admin.css"/>

    <style type="text/css">
        .auto-style1 {
            min-width: 70px;
            text-align: right;
        }
        .Short {
            max-width:90px;
            overflow:hidden;
            white-space:nowrap;
            text-overflow:ellipsis;
            
        }
        .auto-style2 {
            min-width: 70px;
            text-align: right;
            height: 30px;
        }
        .auto-style3 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <!-- upload -->
 
          <fieldset style="width:1280px;">
              <legend>Admin panel
              </legend>
          
          
        <table style="width:100%;">
             <tr>
                <td class="auto-style1">Upload video:</td>
                <td colspan="3">
                     <asp:FileUpload id="FileUploadControl" runat="server" Width="300px" />
                    <asp:RequiredFieldValidator ID="UploadControlValidator" ValidationGroup="Upload" runat="server"
                         ErrorMessage="Choose a video for Upload!" Text="*" ForeColor="Red" ControlToValidate="FileUploadControl"></asp:RequiredFieldValidator>
                </td>
                 <td class="auto-style1">
                     Facebook:
                 </td>
                 <td>
                     <input id="facebookTextBox" type="text" class="TextBox" runat="server" />
                 </td>
            </tr>
             <tr>
                <td class="auto-style2">ID:</td>
                <td colspan="3" class="auto-style3">
                    <input id="Text6" type="text" class="TextBox" readonly="readonly" runat="server" />
                    <asp:RequiredFieldValidator ID="IdValidator_Delete" ValidationGroup="Delete" ControlToValidate="Text6"
                         runat="server" ErrorMessage="Select a video for Deleting!" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="IdValidator_Update" ValidationGroup="Update" ControlToValidate="Text6"
                         runat="server" ErrorMessage="Select a video for Updating!" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                 <td class="auto-style2">
                     Twitter:
                 </td>
                 <td class="auto-style3">
                     <input id="twitterTextBox" type="text" class="TextBox" runat="server" />
                 </td>
            </tr>
            <tr>
                <td class="auto-style1">Name:</td>
                <td>
                    <input id="Text1" type="text" class="TextBox" runat="server" />
                    <asp:RequiredFieldValidator ID="NameValidator_Upload" ValidationGroup="Upload" ControlToValidate="Text1"
                         runat="server" ErrorMessage="Write a name for video!" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="NameValidator_Update" ValidationGroup="Update" ControlToValidate="Text1"
                         runat="server" ErrorMessage="Write a name for video!" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
             <tr style="height:80px;">
                
                <td colspan="2" class="style2" >
                    <asp:Button ID="Button1" runat="server" Text="Upload" Height="30px" Width="90px" OnClick="Button1_Click"
                         CausesValidation="true" ValidationGroup="Upload"/>
                   &nbsp;<asp:Button ID="Button2" runat="server" Height="30px" Text="Update" Width="90px" OnClick="Button2_Click"
                        CausesValidation="true" ValidationGroup="Update" />
                    &nbsp;<asp:Button ID="Button3" runat="server" Height="30px" Text="Delete" Width="90px" OnClick="Button3_Click"
                         CausesValidation="true" ValidationGroup="Delete" />
                    &nbsp;<asp:Button ID="Button4" runat="server" Height="30px" Text="Clear" Width="90px" OnClick="Button4_Click" />
                   </td>
                 <td colspan="4">
                     <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Upload" ForeColor="Red" runat="server" />
                     <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="Update" ForeColor="Red" runat="server" />
                     <asp:ValidationSummary ID="ValidationSummary3" ValidationGroup="Delete" ForeColor="Red" runat="server" />
                 </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Search By Name:
                </td>
                <td colspan="5">
                    <asp:TextBox ID="searchTextBox" Width="300px" AutoPostBack="true" runat="server" OnTextChanged="searchTextBox_TextChanged"></asp:TextBox>
                    <asp:Button ID="searchButton" runat="server" Text="Search" />
                </td>
            </tr>
            <tr>
                <td colspan="6" style="padding-top:20px">
                    <asp:Button ID="moveUpButton" runat="server" Text="Move Up" OnClick="moveUpButton_Click" />
                    <asp:Button ID="MoveDownButton" runat="server" Text="Move Down" OnClick="MoveDownButton_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Videos] ORDER BY [Ordering]" >
                    </asp:SqlDataSource>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="#333333"
                        GridLines="None" BorderWidth="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BorderStyle="Solid"
                         OnRowDataBound="GridView1_RowDataBound" PageSize="7">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" ItemStyle-CssClass="Short" />
                            <asp:BoundField DataField="Ordering" HeaderText="Ordering" SortExpression="Ordering" ItemStyle-CssClass="Short" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" ItemStyle-CssClass="Short" />
                            <asp:BoundField DataField="Path" HeaderText="Path" SortExpression="Path" ItemStyle-CssClass="Short" />
                            <asp:BoundField DataField="Text1" HeaderText="Text1" SortExpression="Text1" ItemStyle-CssClass="Short" />
                            <asp:BoundField DataField="Text2" HeaderText="Text2" SortExpression="Text2" ItemStyle-CssClass="Short" />
                            <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" ItemStyle-CssClass="Short" />
                            <asp:BoundField DataField="Link1" HeaderText="Link1" SortExpression="Link1" ItemStyle-CssClass="Short" />
                            <asp:BoundField DataField="Link2" HeaderText="Link2" SortExpression="Link2" ItemStyle-CssClass="Short" />
                            <asp:BoundField DataField="Facebook" HeaderText="Facebook" SortExpression="Facebook" ItemStyle-CssClass="Short" />
                            <asp:BoundField DataField="Twitter" HeaderText="Twitter" SortExpression="Twitter" ItemStyle-CssClass="Short" />
                            <asp:BoundField DataField="AppStore" HeaderText="AppStore" SortExpression="AppStore" ItemStyle-CssClass="Short" />
                            <asp:BoundField DataField="GooglePlay" HeaderText="GooglePlay" SortExpression="GooglePlay" ItemStyle-CssClass="Short" />
                            <asp:BoundField DataField="Maps" HeaderText="Maps" SortExpression="Maps" ItemStyle-CssClass="Short" />
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

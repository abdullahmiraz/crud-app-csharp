<%@ Page Title="Home Page" Language="C#" MasterPageFile="/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="myapp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="font-size: x-large" align ="center"> Student Info Manage Form<br />
            </div>
            <table class="w-100">
                <tr>
                    <td style="width: 151px">&nbsp;</td>
                    <td style="width: 149px">Student ID</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Font-Size="Medium" OnTextChanged="TextBox1_TextChanged" Width="203px"></asp:TextBox>
                        <asp:Button ID="Button5" runat="server" BackColor="#9900FF" Font-Bold="False" Font-Names="Arial Rounded MT Bold" Font-Size="Medium" ForeColor="White" OnClick="Button5_Click" Text="GET" BorderColor="White" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 151px">&nbsp;</td>
                    <td style="width: 149px">Student Name</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Font-Size="Medium" OnTextChanged="TextBox1_TextChanged" Width="203px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 151px">&nbsp;</td>
                    <td style="width: 149px">Address</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>USA</asp:ListItem>
                            <asp:ListItem>Canada</asp:ListItem>
                            <asp:ListItem>UK</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 151px">&nbsp;</td>
                    <td style="width: 149px">Age</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" Font-Size="Medium" OnTextChanged="TextBox1_TextChanged" Width="203px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 151px">&nbsp;</td>
                    <td style="width: 149px">Contact</td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" Font-Size="Medium" OnTextChanged="TextBox1_TextChanged" Width="203px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 151px">&nbsp;</td>
                    <td style="width: 149px">&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" BackColor="#9933FF" Font-Bold="False" Font-Names="Arial Rounded MT Bold" Font-Size="Medium" ForeColor="White" OnClick="Button1_Click" Text="Insert" />
                        <asp:Button ID="Button2" runat="server" BackColor="#9900FF" Font-Bold="False" Font-Names="Arial Rounded MT Bold" Font-Size="Medium" ForeColor="White" OnClick="Button2_Click" Text="Update" BorderColor="White" />
                        <asp:Button ID="Button3" runat="server" BackColor="#9900FF" Font-Bold="False" Font-Names="Arial Rounded MT Bold" Font-Size="Medium" ForeColor="White" OnClick="Button3_Click" OnClientClick="return confirm('Are you sure to delete?');" Text="Delete" BorderColor="White" />
                        <asp:Button ID="Button4" runat="server" BackColor="#9900FF" Font-Bold="False" Font-Names="Arial Rounded MT Bold" Font-Size="Medium" ForeColor="White" OnClick="Button4_Click" Text="Search" BorderColor="White" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 151px">&nbsp;</td>
                    <td style="width: 149px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 151px">&nbsp;</td>
                    <td style="width: 149px">&nbsp;</td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="591px">
                        </asp:GridView>

                    </td>
                </tr>
            </table> 
    </div>

</asp:Content>

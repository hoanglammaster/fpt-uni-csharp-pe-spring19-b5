<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Q2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <span>Region: </span>
                <asp:DropDownList ID="region" AutoPostBack="true" OnSelectedIndexChanged="region_SelectedIndexChanged" runat="server" Width="133px"></asp:DropDownList>
            </p>
            <p>
                <span>Corporation: </span>
                <asp:DropDownList ID="corporation" AutoPostBack="true" runat="server" Width="147px"></asp:DropDownList>
            </p>
            <p>
                <span>First Name: </span>
                <asp:TextBox ID="firstName" runat="server"></asp:TextBox>
            </p>
            <p>
                <span>Last Name: </span>
                <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:button id="addMember" text="add member" onclick="addMember_Click" runat="server" />
            </p>
            <p><asp:Label ID="messageLabel" runat="server"></asp:Label></p>
            
        </div>
    </form>
</body>
</html>

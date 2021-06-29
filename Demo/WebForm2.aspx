<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Demo.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%--<div>
             <p>
                <span>Region: </span>
                <asp:DropDownList ID="region" AutoPostBack="true" OnSelectedIndexChanged="region_SelectedIndexChanged" runat="server" Width="133px"></asp:DropDownList>
            </p>
            <p>
                <span>Corporation: </span>
                <asp:DropDownList ID="corporation" AutoPostBack="true" runat="server" Width="147px"></asp:DropDownList>
            </p>
        </div>--%>
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
                <asp:Button ID="AddMember" Text="Add member" OnClick="AddMember_Click" runat="server"/>
            </p>
            
        </div>
    </form>
</body>
</html>

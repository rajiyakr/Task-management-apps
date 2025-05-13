<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ToDoList.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-left: 0px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <br />
    <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
        <asp:View ID="View2" runat="server">
           
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
            <asp:Button ID="Button1" runat="server" Font-Bold="false" ForeColor="YellowGreen" Font-Size="50px" Text="View project status" OnClick="Button1_Click"/>
            <br />
            <br />
            <br />
            <asp:Calendar ID="Calendar1"  runat="server" SelectionMode="Day" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" CssClass="auto-style2" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="168px" OnSelectionChanged="Calendar1_SelectionChanged" ShowGridLines="True" Width="233px">
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
            <br />
            <asp:TextBox ID="TextBox3" runat="server" class="form-control" width="35%" OnTextChanged="TextBox3_TextChanged" BorderColor="Black"></asp:TextBox>
            <asp:Button ID="Button4" runat="server" class="form-control" Width="100px" BackColor="#003399" ForeColor="White" Font-Size="Large" Font-Bold="true" OnClick="Button4_Click" Text="Show All"/>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" BackColor="White" width="80%" BorderColor="Black" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Number" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" />
                    <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" class="form-control" BorderColor="Black" width="60%"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" class="form-control" BorderColor="Black" width="60%"></asp:TextBox>
            <asp:Button ID="Button3" class="form-control" Width="100px" BackColor="#003399" ForeColor="White" Font-Size="Large" Font-Bold="true" runat="server" OnClick="Button3_Click" Text="Add" />
        </asp:View>
        <asp:View ID="View3" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:GridView ID="GridView2" BackColor="White" width="100%" BorderColor="Black" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="SerialNumber" HeaderText="Number" />
                    <asp:BoundField DataField="Tasks" HeaderText="Task" />
                    <asp:BoundField DataField="Date" HeaderText="Date" />
                    <asp:CheckBoxField DataField="Done" HeaderText="Status" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>
        
</asp:Content>

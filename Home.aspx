<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ToDoList.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style2 {
            margin-left: 111px;
        }
        .transparent-background {
    background-color: rgba(0, 128, 255, 0); /* Fully transparent blue */
}

        </style>
     <script type="text/javascript">
        function showElements() {
            var textBox6 = document.getElementById('<%= TextBox6.ClientID %>');
            var textBox2 = document.getElementById('<%= TextBox2.ClientID %>');
            var myButton = document.getElementById('<%= Button6.ClientID %>');
            var myButton2 = document.getElementById('<%=Button7.ClientID %>');
            var listBox = document.getElementById('<%=ListBox1.ClientID %>');
            var textBox3 = document.getElementById('<%=TextBox3.ClientID%>');
            var panel = document.getElementById('<%= hided.ClientID %>');



            textBox6.style.display = 'block' ;
            textBox2.style.display = 'block';
            myButton.style.display = 'inline-block' ;
            myButton2.style.display = 'inline-block';
            listBox.style.display = 'block';
            textBox3.style.display = 'block';
            panel.style.display = 'block';

         }

         function hideElements() {
              var textBox6 = document.getElementById('<%= TextBox6.ClientID %>');
              var textBox2 = document.getElementById('<%= TextBox2.ClientID %>');
              var myButton = document.getElementById('<%= Button6.ClientID %>');
              var myButton2 = document.getElementById('<%=Button7.ClientID %>');
             var listBox = document.getElementById('<%=ListBox1.ClientID %>');
             var textBox3 = document.getElementById('<%=TextBox3.ClientID%>');
             var panel = document.getElementById('<%= hided.ClientID %>');



             textBox6.style.display = 'none';
             textBox2.style.display = 'none';
             myButton.style.display = 'none';
             myButton2.style.display = 'none';
             listBox.style.display = 'none';
             textBox3.style.display = 'none';
             panel.style.display = 'none';
             return false; // Prevent postback

          }
     </script>
  
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ListBox ID="ListBox2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" style="display: none"></asp:ListBox>
       
        <asp:Label ID="Label4" runat="server" ForeColor="White" CssClass="transparent-background" Text="Welcome "></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" style="border:none" ForeColor="White" CssClass="transparent-background"></asp:TextBox>
       
       <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px" OnSelectionChanged="Calendar1_SelectionChanged">
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" style="display: none"></asp:ListBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Show Table" BackColor="Yellow" />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Close" BackColor="Yellow" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Add New" BackColor="Yellow" OnClientClick="showElements(); return false;"/>
        </p>
    <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
    <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Show All" />
    <br />
    <br />
    <asp:Panel ID="hided" runat="server" style="border: 1px solid black; background-color:forestgreen; display: none"  >
    <p style="display:none">
        <asp:Label ID="Label6" runat="server" Text="Number" style="display: none" ></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox6" runat="server" style="display: none"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" style="display: none"></asp:TextBox>
        </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Task"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="What I learnt"></asp:Label>
        &nbsp;
        <asp:TextBox ID="TextBox3" runat="server"  ></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button6" runat="server" Text="Add" BackColor="Yellow" OnClick="Button6_Click"  ></asp:Button>
        <asp:Button ID="Button7" runat="server" Text="Cancel" BackColor="Yellow" OnClientClick="hideElements(); return false;" />
    </p>
   </asp:Panel>
    <p>
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="Id" width="90%" AutoGenerateColumns="False" Height="126px" OnRowEditing="GridView1_RowEditing"  OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" BackColor="LightPink" CssClass="auto-style2">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="SerialNumber" HeaderText="Number" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Tasks" HeaderText="Tasks" />
                <asp:CheckBoxField DataField="Done" HeaderText="Done" />
                <asp:BoundField DataField="Description" HeaderText="What I leart" />
                <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" />
                <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        
        </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
</asp:Content>

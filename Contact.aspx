<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    <h2><%: Title %>.</h2>
    <h3>Send us your query</h3>
      <div class="row">
        <div class="col-md-4">
            
            <p>
                
                <asp:Label ID="lblName" runat="server" Width="100px" Text="Name"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Width="260px" ></asp:TextBox> <br />
                  
          <asp:Label ID="Label1" runat="server" Width="100px" Text="Query " ></asp:Label>
                <asp:DropDownList ID="ddldrop" runat="server" Style="height: 30px; width: 260px">
                    <asp:ListItem Text="<--Select-->"></asp:ListItem>
                    <asp:ListItem Text="Statement"></asp:ListItem>
                    <asp:ListItem Text="Margin"></asp:ListItem>
                    <asp:ListItem Text="IT"></asp:ListItem>
                </asp:DropDownList> <br />
                <asp:Label ID="Label2" runat="server" Text="Message" Width="100px"></asp:Label>
                <asp:TextBox ID="TextBox2" TextMode="MultiLine" Height="100px" Width="260px" runat="server"></asp:TextBox> <br />

                <asp:Button ID="btnSave" runat="server" class="btn btn-default" Text="Save    "  />
                
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more Details</h2>
            <p>
               We are enhancing our client relationship portal in the coming days . To learn more click the below link 
            </p>
            <p>
               
                 <li><a runat="server" text="Learn More" target="_blank" class="btn btn-default" href="https://www.orionprincipals.com/"> Learn More</a></li>
                
            </p>
        </div>
        <div class="col-md-4">
            <h2>News updates</h2>
            <p>
               Check for lates news updates under OPL news column . Click the below link to learn more 
            </p>
            <p>
                 <li><a runat="server" text="Learn More" class="btn btn-default" href="~/News"> OPL News</a></li>
            </p>
        </div>
    </div>

    <address>
        <strong>Contact:</strong>   <a href="mailto:Contact@orionprinciapls.com">Contact@orionprincipals.com</a><br />
    </address>
        </div>
</asp:Content>

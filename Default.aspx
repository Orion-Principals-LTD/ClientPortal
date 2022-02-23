<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">

        <h2><b>
            <marquee behavior="alternate" bgcolor="red"> This application is currently in Testing Region . However the calculated components are real time and live </marquee>
            <asp:Label ID="lblClientName" Text="Client Name" runat="server"></asp:Label>
        </b></h2>
        <div style="padding-top: 1px;">
            <h5>
                <asp:Label ID="Label1" Text="Below data shows your current position and balance summary as of now with Orion Principals" runat="server"></asp:Label>

            </h5>
        </div>
        <h2>
            <asp:DropDownList ID="ddlClient" runat="server" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
        </h2>

        <div style="padding-top: 1px;">
            <h2>
                <asp:Label ID="lblMargin" runat="server" Text=""></asp:Label> 
            </h2>
            <h6>
                <b >
                 <asp:Label ID="lblnav_colla" runat="server"   Text=""></asp:Label><br />
                <asp:Label ID="lblMarginUpdtTime" Text="" runat="server"></asp:Label>
                   
            </b></h6>
        </div>


    </div>

    <h3>
        <b>Open Positions </b>
    </h3>
    <div class="table-responsive">
        <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-condensed table-responsive table-hover" HeaderStyle-BackColor="#efefef" Style="width: 2000px" AutoGenerateColumns="true"
            EmptyDataText="No records found">
        </asp:GridView>
    </div>
    <%--   <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>

    <%--<asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-condensed table-responsive table-hover" HeaderStyle-BackColor="#efefef" Style="width: 1500px"></asp:GridView>--%>

    <h3>
        <b>Balance Summary </b>
    </h3>
    <div class="table-responsive">
        <asp:GridView ID="GridView3" runat="server" CssClass="table table-bordered table-condensed table-responsive table-hover" HeaderStyle-BackColor="#efefef" Style="width: 2000px"></asp:GridView>
    </div>

    <h3>
        <b>Limit Check </b>
      

    </h3>
    <h4>
          <asp:DropDownList ID="ddlTicker_check" runat="server" Height="25px" Width="150px" OnSelectedIndexChanged="ddlTicker_check_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        <asp:TextBox ID="txtMarketPrice"  runat="server" Width="130px" placeholder="Market Price" TextMode="Number" onkeypress="return DecimalValidateEightPoints(event)" ></asp:TextBox>
        <asp:TextBox ID="txtToUSD"  runat="server" Width="130px" Enabled="false" placeholder=" To USD" TextMode="Number" onkeypress="return DecimalValidateEightPoints(event)" ></asp:TextBox>
        <asp:TextBox ID="txtUtilization" MaxLength="2" Text="70" runat="server" Width="150px" placeholder="Utilization NAV" TextMode="Number" onkeypress="return DecimalValidateEightPoints(event)" ></asp:TextBox>
        <asp:Button ID="btnGetLatest" OnClick="btnGetLatest_Click" runat="server" Text="Get Latest" />
    </h4>
    <div class="table-responsive">
        <asp:GridView ID="gvLimit" runat="server" CssClass="table table-bordered table-condensed table-responsive table-hover" 
            HeaderStyle-BackColor="#efefef" Style="width: 2000px" AutoGenerateColumns="false">
            <Columns>
              
                  <asp:BoundField DataField="Market Price" HeaderText="Market Price" />
                  <asp:BoundField DataField="Margin" HeaderText="Margin" />
                  <asp:BoundField DataField="Utilization Of NAV" HeaderText="Utilization Of NAV" />
                  <asp:BoundField DataField="NAV Utilization Max" HeaderText="NAV Max Utilization" />
                  <asp:BoundField DataField="Current Collateral" HeaderText="Collateral" />
                 <asp:BoundField DataField="Reach Utilization" HeaderText="ToReachUtilization" />
                 <asp:BoundField DataField="Buy Capacity" HeaderText="Buynig Capacity" />
            </Columns>
        </asp:GridView>
    </div>
    <h6><b>
        <asp:Label ID="lblPostionLastUpDtTime" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label3" Text="" runat="server"></asp:Label>
    </b></h6>
    <%--  <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>

                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Save" runat="server" Style="padding: 3px" Width="130px" Text="Save" OnClick="Save_Click" />
                <asp:DropDownList ID="ddldrop" runat="server" Style="height: 25px; width: 220px">
                    <asp:ListItem Text="<--Select-->"></asp:ListItem>
                    <asp:ListItem Text="Product"></asp:ListItem>
                    <asp:ListItem Text="Item"></asp:ListItem>
                    <asp:ListItem Text="verity"></asp:ListItem>
                </asp:DropDownList>

                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>--%>
</asp:Content>

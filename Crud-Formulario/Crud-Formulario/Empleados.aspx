<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="Crud_Formulario.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Empleados</h1>
    <asp:Label ID="lbl_codigo" runat="server" Text="Codigo" CssClass="badge" Font-Size="Large" ForeColor="#333300"></asp:Label>
    <asp:TextBox ID="txt_codigo" runat="server" CssClass="form-control" placeholder="Codigo"></asp:TextBox>
    
    <asp:Label ID="lbl_nombre" runat="server" Text="Nombre" CssClass="badge" Font-Size="Large" ForeColor="#333300"></asp:Label>
    <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
    
    <asp:Label ID="lbl_apellido" runat="server" Text="Apellido" CssClass="badge" Font-Size="Large" ForeColor="#333300"></asp:Label>
    <asp:TextBox ID="txt_apellido" runat="server" CssClass="form-control" placeholder="Apellido"></asp:TextBox>

    <asp:Label ID="lbl_direccion" runat="server" Text="Direccion" CssClass="badge" Font-Size="Large" ForeColor="#333300"></asp:Label>
    <asp:TextBox ID="txt_direccion" runat="server" CssClass="form-control" placeholder="Eje: #casa calle principal y avenida del lugar "></asp:TextBox>

    <asp:Label ID="lbl_telefono" runat="server" Text="Telefono" CssClass="badge" Font-Size="Large" ForeColor="#333300"></asp:Label>
    <asp:TextBox ID="txt_telefono" runat="server" CssClass="form-control" placeholder="0321654987" TextMode="Number"></asp:TextBox>

    <asp:Label ID="lbl_fn" runat="server" Text="Fecha nacimiento" CssClass="badge" Font-Size="Large" ForeColor="#333300"></asp:Label>
    <asp:TextBox ID="txt_fn" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd" TextMode="Date"></asp:TextBox>

    <asp:Label ID="lbl_puesto" runat="server" Text="Puesto" CssClass="badge" Font-Size="Large" ForeColor="#333300"></asp:Label>
    <asp:DropDownList ID="drop_puesto" runat="server" CssClass="form-control" OnSelectedIndexChanged="drop_puesto_SelectedIndexChanged"></asp:DropDownList>
    
    <asp:Button ID="btn_crear" runat="server" Text="Crear" CssClass="btn btn-outline-primary" OnClick="btn_crear_Click"/>
    <asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" CssClass="btn btn-outline-success" Visible="False" OnClick="btn_actualizar_Click" />
    
    <asp:Label runat="server" ID="lbl_mensaje"></asp:Label>  

    

    <asp:GridView ID="grid_empleado" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="id,id_puesto" OnSelectedIndexChanged="grid_empleado_SelectedIndexChanged" OnRowDeleting="grid_empleados_RowDeleting">
        <Columns>
            <asp:BoundField DataField="codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="nombres" HeaderText="Nombres" />
            <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
            <asp:BoundField DataField="direccion" HeaderText="Direccion" />
            <asp:BoundField DataField="telefonos" HeaderText="Telefono" />
            <asp:BoundField DataField="fecha_nacimiento" HeaderText="Nacimiento" />
            <asp:BoundField DataField="puesto" HeaderText="Puesto" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btn_seleccionar" runat="server" CausesValidation="False" CommandName="Select" Text="Ver" CssClass="btn btn-primary"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btn_eliminar" runat="server" CausesValidation="False" CommandName="Delete" Text="Borrar" CssClass="btn btn-danger" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            Tabla Vacia<br />
        </EmptyDataTemplate>
        <PagerTemplate>
            Tabla Vacia
        </PagerTemplate>
    </asp:GridView>
</asp:Content>

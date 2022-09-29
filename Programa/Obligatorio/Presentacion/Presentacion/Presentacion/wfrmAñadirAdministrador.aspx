<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmAñadirAdministrador.aspx.cs" Inherits="Presentacion.Presentacion.wfrmAñadirAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 3%; background-image: url(https://fondosmil.com/fondo/25803.jpg); border-radius: 5px;">
        <div style="display: flex; justify-content: center; align-items: center">
            <div class="mError mt-2" id="visibilidad1" runat="server" style="position: absolute;">
                <svg xmlns="http://www.w3.org/2000/svg" style="display: none;">
                    <symbol id="exclamation-triangle-fill" fill="currentColor" viewBox="0 0 16 16">
                        <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" />
                    </symbol>
                </svg>
                <div class="alert alert-danger" role="alert" style="height: 55px">
                    <svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Danger:" style="float: left">
                        <use xlink:href="#exclamation-triangle-fill" />
                    </svg>
                    <div style="float: left;">
                        Ocurrio un error revise los datos.
                    </div>
                </div>
            </div>
            <div class="mExito mt-2" id="visibilidad2" runat="server" style="position: absolute;">
                <svg xmlns="http://www.w3.org/2000/svg" style="display: none;">
                    <symbol id="check-circle-fill" fill="currentColor" viewBox="0 0 16 16">
                        <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zm-3.97-3.03a.75.75 0 0 0-1.08.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-.01-1.05z" />
                    </symbol>
                </svg>
                <div class="alert alert-success" role="alert" style="height: 55px">
                    <svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Success:" style="float: left">
                        <use xlink:href="#check-circle-fill" />
                    </svg>
                    <div style="float: left;">
                        Accion realizada con exito.
                    </div>
                </div>
            </div>
        </div>
        <h1 style="text-align: center; margin-bottom: 1%; color:white">Gestión Administradores</h1>
        <div class="row">
            <div class="col-sm-6">
                <h3 style="text-align: center; color:white">Usuarios</h3>
                <asp:ListBox ID="lstUsuario" class="form-control" runat="server" Style="height: 400px"></asp:ListBox>
            </div>
            <div class="col-sm-6">
                <h3 style="text-align: center; color:white">Administradores</h3>
                <asp:ListBox ID="lstAdministrador" class="form-control" runat="server" Style="height: 400px"></asp:ListBox>
            </div>
        </div>
        <div class="row" style="margin-top: 2%;">
            <div class="col-sm-12" style="display: flex; align-items: center; justify-content: center; margin-bottom: 2%">
                <asp:Button ID="btnAñadir" runat="server" Style="margin-left: 1%; margin-right: 1%" class="btn btn-outline-success" Text="Añadir Admin" OnClick="btnAñadir_Click" />
                <asp:Button ID="btnEliminar" runat="server" Style="margin-left: 1%; margin-right: 1%" class="btn btn-outline-danger" Text="Eliminar Admin" OnClick="btnEliminar_Click" />
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmRegistroUsuario.aspx.cs" Inherits="Presentacion.Presentacion.wfrmRegistroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="margin-left:0;margin-right:0; margin-top:1%">
        <div class="col-sm-2"></div>
        <div class="col-sm-8"></div>
        <div class="col-sm-2">
            <asp:Button ID="btnIniciarSesion" runat="server" class="botonIn" Text="Iniciar Sesion" style="float:right" OnClick="btnIniciarSesion_Click" />
        </div>
    </div>
    <h1 style="text-align: center; color: white">Taller Mecanico</h1>
    <div class="row" style="margin-right:0; margin-left:0;">
        <div class="col-sm-3"></div>
        <div class="col-sm-6" style="background-image: url(https://img.freepik.com/vector-gratis/fondo-textura-elegante-blanco_23-2148433720.jpg?w=2000); border-radius: 5px; margin-top: 1%">
            <h3 style="text-align: center; margin-top: 1%">Registrate</h3>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox TextMode="SingleLine" class="form-control" ID="txtNombre" placeholder="Osvaldo" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtCi" class="form-label">Cédula de Identidad</label>
                <asp:TextBox TextMode="SingleLine" class="form-control" ID="txtCi" placeholder="X.XXX.XXX-X" runat="server" />
            </div>
            <asp:RegularExpressionValidator 
                     ID="RegularExpressionValidatorCI" 
                     runat="server"
                     ControlToValidate="txtCi"
                     ErrorMessage="Ingrese una cedula valida"
                     ForeColor="White"
                     ValidationExpression="[1-9]{1}.[0-9]{3}.[0-9]{3}-[0-9]{1}"
            />
            <div class="mb-3">
                <label for="txtTelefono" class="form-label">Télefono</label>
                <asp:TextBox TextMode="Phone" class="form-control" ID="txtTelefono" placeholder="099876543" runat="server" />
            </div>
             <asp:RegularExpressionValidator 
                     ID="RegularExpressionValidatorTel" 
                     runat="server"
                     ControlToValidate="txtTelefono"
                     ErrorMessage="Ingrese un telefono valido"
                     ForeColor="White"
                     ValidationExpression="0[0-9]{8}"
            />
            <div class="mb-3">
                <label for="txtDireccion" class="form-label">Dirección</label>
                <asp:TextBox TextMode="SingleLine" class="form-control" ID="txtDireccion" placeholder="Daniel Fernandez Crespo 700" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtMail" class="form-label">Correo Electronico</label>
                <asp:TextBox TextMode="Email" class="form-control" ID="txtMail" placeholder="elsabrosopan@gmail.com" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Contraseña</label>
                <asp:TextBox TextMode="Password" class="form-control" ID="txtPass" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnRegistrar" runat="server" class="btn btn-outline-dark" Text="Registrarse" OnClick="btnRegistrar_Click" Width="100%" />
            </div>
        </div>
        <div class="col-sm-3"></div>
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <div class="mError mt-2" id="visibilidad1" runat="server">
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
                <div class="mExito mt-2" id="visibilidad2" runat="server">
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
            <div class="col-sm-2"></div>
        </div>
    </div>
</asp:Content>

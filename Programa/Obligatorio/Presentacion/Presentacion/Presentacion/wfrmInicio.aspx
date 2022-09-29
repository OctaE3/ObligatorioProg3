<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmInicio.aspx.cs" Inherits="Presentacion.Presentacion.wfrmInicio" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row" style="margin-top: 3%">
            <div class="col-sm-1"></div>
            <div class="col-sm-5">
                <div style="display: flex; justify-content: center; align-items: center; margin-top: 28%">
                    <h1 style="font-size: 600%">Taller</h1>
                </div>
                <div style="display: flex; justify-content: center; align-items: center;">
                    <h2>Servicio Mecánico</h2>
                </div>
                <div style="display: flex; justify-content: center; align-items: center;">
                    <a class="test" href="wfrmReserva.aspx" runat="server">Agendar Reserva</a>
                </div>
            </div>
            <div class="col-sm-5">
                <div>
                    <img src="https://i.ibb.co/ww8Fq1X/Sin-t-tulo-1.png" style="width: 100%; border-radius: 300px;" />
                </div>
            </div>
            <div class="col-sm-1"></div>
        </div>
    </div>
    <div style="background-color: #DEDEDE; margin-top: 3%;">
        <div class="row" style="padding: 0; margin: 0;">
            <div class="col-sm-3"></div>
            <div class="col-sm-6">
                <div style="display: flex; justify-content: center; align-items: center;">
                    <img src="~/Estilos/logo.png" runat="server" style="width: 30%" />
                </div>
                <div style="text-align: center">
                    Somos mecánicos integrales para automotores con más de 10 años de experiencia, que a través del diagnóstico y prevención de cada vehículo velamos por el bien más preciado de nuestros clientes, su vida. 
                    <p style="font-weight: bold">Generamos más kilómetros de confianza.</p>
                </div>
                <div style="text-align: center; margin-top: 6%">
                    <h2 style="font-weight: bold">Repuestos a la venta</h2>
                </div>
            </div>
            <div class="col-sm-3"></div>
        </div>
    </div>
    <div class="container">
        <div class="row" style="padding: 0; margin: 0; margin-top: 4%">
            <div class="col-sm-3">
                <div class="card" style="width: 18rem;">
                    <img src="//f.fcdn.app/imgs/01f371/www.cymaco.com.uy/cym/6951/webp/catalogo/J3.630/460_460/alternador-jac-j3-85amp-5pk-alternador-jac-j3-85amp-5pk.jpg" class="card-img-top" alt="Alternador JAC J3 85AMP 5PK">
                    <div class="card-body">
                        <h5 class="card-title">ALTERNADOR JAC J3 85AMP 5PK</h5>
                    </div>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="card" style="width: 18rem;">
                    <img src="//f.fcdn.app/imgs/4f3c4c/www.cymaco.com.uy/cym/8520/webp/catalogo/Q22.641/460_460/llave-bajo-volante-chery-luces-q22-karry-llave-bajo-volante-chery-luces-q22-karry.jpg" class="card-img-top" alt="LLAVE BAJO VOLANTE CHERY LUCES Q22 KARRY">
                    <div class="card-body">
                        <h5 class="card-title">LLAVE BAJO VOLANTE CHERY LUCES Q22 KARRY</h5>
                    </div>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="card" style="width: 18rem;">
                    <img src="//f.fcdn.app/imgs/57eb15/www.cymaco.com.uy/cym/e038/webp/catalogo/Q22.709L/460_460/faro-caminero-chery-q22-karry-izq-faro-caminero-chery-q22-karry-izq.jpg" class="card-img-top" alt="FARO CAMINERO CHERY Q22 KARRY IZQ">
                    <div class="card-body">
                        <h5 class="card-title">FARO CAMINERO CHERY Q22 KARRY IZQ</h5>
                    </div>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="card" style="width: 18rem;">
                    <img src="//f.fcdn.app/imgs/c7ff81/www.cymaco.com.uy/cym/1a9b/webp/catalogo/S2.592/460_460/bieleta-suspension-jac-s2-bieleta-suspension-jac-s2.jpg" class="card-img-top" alt="BIELETA SUSPENSION JAC S2">
                    <div class="card-body">
                        <h5 class="card-title">BIELETA SUSPENSION JAC S2</h5>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row" style="padding: 0; margin: 0; margin-top: 4%; background-color: black;">
        <div class="col-sm-6" style="display:flex; justify-content:center; align-items:center">
            <img src="https://i.ibb.co/dJPt2ZF/alito.png" style="width: 100%; "/>
        </div>
        <div class="col-sm-6">
            <div style="text-align:center; margin-top: 10%; color:white">
                <h1>Sobre Nosotros</h1>
            </div>
            <div style="color: white; margin-top:8%;text-align:center; font-size:130%">
                Somos mecánicos que desarrollamos nuestro trabajo en el cuidado y mantenimiento de nuestra gran pasión, los autos. 
                No sólo por cuidar una inversión o un bien material, sino que a través del diagnóstico y prevención de cada vehículo velamos por el bien más preciado de nuestros clientes, su vida.
                Y es por eso que estamos motivados en atender cada detalle, como si cada vez que encendés tu motor y salís a la ruta, viajáramos contigo. Desde hace más de 10 años, el objetivo de nuestro compromiso es generar más kilómetros de confianza.
            </div>
        </div>
    </div>
</asp:Content>

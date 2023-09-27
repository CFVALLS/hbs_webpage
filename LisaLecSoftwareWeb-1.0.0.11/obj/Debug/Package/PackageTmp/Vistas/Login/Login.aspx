<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LisalecWeb.Vistas.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-3.6.4.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/sweetalert2.all.min.js"></script>
    

    <title>HBS Energía</title>
</head>
<body>
       <div class="container login-container">
            <div class="row">
                <div class="col-md-6 login-form-1">
                    <center>
                        <h1 class="text-secondary"></h1><br />
                        <h4 class="text-secondary">Iniciar sesión</h4>
                    </center>
                    <form autocomplete="off">   
                        <hr />                     
                        <div class="form-group">
                            <input type="text" class="form-control" placeholder="Usuario" value="" id="usu" autocomplete="off"  />
                        </div>
                        <br />
                        <div class="form-group">
                            <input type="password" class="form-control" placeholder="Contraseña" value="" id="pass"  autocomplete="off" />
                        </div>
                        <br />
                        <div class="form-group" style="align-content: center;">
                            <input type="button" class="btnSubmit" id="btnEntrar" value="Iniciar sesión" />
                        </div>
                        <hr />
                         <div class="form-group" style="align-content: center;">
                            <a href="#" class="link-primary">Recuperar contraseña</a>
                        </div>
                    </form>
                </div>  
                <div class="col-md-6 login-form-1" style="background-image: url('../../Resources/icon_3554304.jpg'); background-repeat: no-repeat; background-size:100% 100%;">
               
                </div>                
            </div>
        </div>

        
        <!-- Footer -->
    <footer class="page-footer font-small blue pt-4">

        <!-- Footer Links -->
        <div class="container-fluid text-center text-md-left">
        </div>
        <!-- Footer Links -->
        <br />
        <br />
        <!-- Copyright -->
        <div class="footer-copyright text-center py-3">
            © 2023 Copyright:
                <a href="#">CloudConnection</a>
        </div>
        <!-- Copyright -->

    </footer>
<!-- Footer -->
   
</body>

</html>

<script>

    $(document).ready(function () {
       
        $("#btnEntrar").click(function () {

            var jSonData = "{"
                + "'usu': '" + $("#usu").val()
                + "','pass': '" + $("#pass").val()
                + "'}";
            $.ajax(
                {
                    url: "login.aspx/login",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        $("body").append(result.d);
                    },
                    error: function (xhr, status, error) {
                        swal(
                            '¡ Error sistema:( !',
                            'Error en el sistema, favor intentar nuevamente',
                            'warning'
                        );
                    }
                });

        });

        function load() {
           
            var jSonData = "{'key': 'key'}";
            $.ajax(
                {
                    url: "Login.aspx/load",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        $("body").append(result.d);
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

        }

        load();
        
    });


</script>

<style>
    .login-container {
        margin-top: 5%;
        margin-bottom: 5%;
    }

    .login-form-1 {
        padding: 5%;
        box-shadow: 0 5px 8px 0 rgba(0, 0, 0, 0.2), 0 9px 26px 0 rgba(0, 0, 0, 0.19);
    }

        .login-form-1 h3 {
            text-align: center;
            color: #333;
        }

    .login-form-2 {
        padding: 5%;
        background: #0062cc;
        box-shadow: 0 5px 8px 0 rgba(0, 0, 0, 0.2), 0 9px 26px 0 rgba(0, 0, 0, 0.19);
    }

        .login-form-2 h3 {
            text-align: center;
            color: #fff;
        }

    .login-container form {
        padding: 10%;
    }

    .btnSubmit {
        width: 50%;
        border-radius: 1rem;
        padding: 1.5%;
        border: none;
        cursor: pointer;
    }

    .login-form-1 .btnSubmit {
        font-weight: 600;
        color: #fff;
        background-color: #0062cc;
    }

    .login-form-2 .btnSubmit {
        font-weight: 600;
        color: #0062cc;
        background-color: #fff;
    }

    .login-form-2 .ForgetPwd {
        color: #fff;
        font-weight: 600;
        text-decoration: none;
    }

    .login-form-1 .ForgetPwd {
        color: #0062cc;
        font-weight: 600;
        text-decoration: none;
    }
</style>

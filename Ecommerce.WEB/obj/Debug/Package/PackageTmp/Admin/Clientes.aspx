<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Ecommerce.WEB.Admin.Clientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administração de Clientes</title>

    <link href="../css/jtable.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.8.3.min.js" type="text/javascript"></script>

    <script src="../js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../js/modernizr-1.7.min.js" type="text/javascript"></script>
    <script src="../js/jtablesite.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="../js/json2.js"></script>
    <script type="text/javascript" src="../js/jquery.jtable.js"></script>
    <script type="text/javascript" src="../js/jquery.jtable.aspnetpagemethods.js"></script>

</head>
<body>
    <div class="site-container">
        <div class="StudentTableContainer">
        </div>
            <script type="text/javascript">

                $(document).ready(function () {

                    //Prepare jtable plugin
                    $('#StudentTableContainer').jtable({
                        title: 'Lista De Clientes',
                        paging: true,
                        pageSize: 10,
                        sorting: true,
                        defaultSorting: 'Name ASC',
                        actions: {
                            listAction: '/Admin/Clientes.aspx/ClienteLista',
                            createAction: '/Clientes.aspx/CreateStudent',
                            updateAction: '/Clientes.aspx/UpdateStudent',
                            deleteAction: '/Clientes.aspx/DeleteStudent'
                        },
                        fields: {
                            IDT_CLIENTE: {
                                key: true,
                                create: false,
                                edit: false,
                                list: false
                            },
                            NOME: {
                                title: 'Name',
                                width: '23%'
                            },
                            EMAIL: {
                                title: 'Email address',
                                list: false
                            },
                            SENHA: {
                                title: 'Senha Usuario',
                                type: 'password',
                                list: false
                            },
                            DATA_CADASTRO: {
                                title: 'Record date',
                                width: '15%',
                                type: 'date',
                                displayFormat: 'dd-mm-yy',
                                create: false,
                                edit: false,
                                sorting: false //This column is not sortable!
                            },
                            TELEFONE: {
                                title: 'Telefone',
                                width: '23%'
                            }
                        }
                    });

                    //Load student list from server
                    $('#StudentTableContainer').jtable('load');
                });

    </script>
    </div>
</body>
</html>

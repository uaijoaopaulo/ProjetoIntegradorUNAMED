<%@ Page Title="Sobre unNamed" Language="C#" MasterPageFile="~/View/_LayoutPaginaAssistente.Master" AutoEventWireup="true" CodeBehind="SobreView.aspx.cs" Inherits="ProjetoIntegrador.View.SobreView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Style/EstiloPaginaAssistente.css" rel="stylesheet" />
    <h1>Sobre o unNamed</h1>
    <p>Criado por João Paulo Bráulio em Maio de 2018.</p>
    <p>Para o PI (Projeto Integrador) do 5º (Quinto) Período do curso de Sistemas de Informação da Faculdade CNEC de Unaí, Minas Gerais.</p>
    <p>Orientado Pelo Professores: Gustavo Henrique na programação e Rodolfo dos Santos no banco de dados.</p>
    <br />
    <p>unNamed é um sistema de integração social.</p>
    <asp:Button ID="bttVoltar" runat="server" Text="Voltar" OnClick="bttVoltar_Click" CssClass="bttVoltar" />
</asp:Content>

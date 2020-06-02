function clickMostraAreaPesquisa() {
    event.preventDefault();
    var AreaPesquisa = document.getElementById("pnlRetornoPesquisa");
    AreaPesquisa.classList.toggle('toggleAreaRetornoPesquisa');
}
function clickAreaOpcoes() {
    event.preventDefault();
    var AreaOpcoes = document.getElementById("pnlAreaOpcoes");
    AreaOpcoes.classList.toggle('toggleAreaOpcoes');
}
function clickButton() {
    event.preventDefault();
    var menuLateral = document.getElementById("pnlTimeline");
    menuLateral.classList.toggle('toggleTimeline');
}
function clickMensagemButtom() {
    clickButton();
    var notificacaoM = document.getElementById("pnlMensagem");
    notificacaoM.classList.toggle('toggleMensagem');
}
function clickNotificacaoButtom() {
    clickButton();
    var notificacao = document.getElementById("pnlNotificacao");
    notificacao.classList.toggle('toggleNotificacoes');
}
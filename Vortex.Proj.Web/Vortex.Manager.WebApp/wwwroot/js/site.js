var notification = {
    addNotification : (mensagem, type) => {

        //console.log(mensagem)
        //console.log(type) 

        $("#notificacao-erro").html('')
        $("#notificacao-erro").html(`${mensagem}`)
        $("#notificacao-erro").css("background", "rgb(217 0 0 / 84%)");

        if (type === 'ok') {
            $("#notificacao-erro").css("background", "#26e50d");
        }

        // Com botão de fechar:
        $("#notificacao-erro").append('<span id="fechar-erro" style="float:right; cursor:pointer;">&times;</span>');
        $("#fechar-erro").click(function () {
            $("#notificacao-erro").fadeOut();
        });

        $("#notificacao-erro").fadeIn();
        setTimeout(function () {
            $("#notificacao-erro").fadeOut();
        }, 5000); // 5000 milissegundos = 5 segundos 
    }
}
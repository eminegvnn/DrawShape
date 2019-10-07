$(function () {
    document.onkeypress = function (e) {
        getShape(e.keyCode);  //Kullanıcının tuşlama eventi yakalanır
    };

    function getShape(shapeCode) {
        //Kullanıcının girdiği keyCode fonksiyona parametre olarak gönderilir.
        var dataPost = { enteredShapeCode: shapeCode };
        $.ajax({
            url: '/Shapes/GetShape',
            dataType: "json",
            data: dataPost,
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data != "")
                    drawShape(data);
                else
                    alert("Geçersiz tuşlama!")
            },
            error: function (xhr) {
                alert('Hata Oluştu!');
            }
        })
    }
});

function drawShape(shape) {
    var canvas = $('<canvas/>'); //Her şekil için canvas oluşturulur.
    var ctx = canvas[0].getContext('2d');
    ctx.beginPath(); 
    ctx.font = "normal 20px Verdana";
    ctx.strokeStyle = "#000";  
    ctx.textAlign = "start";
      //Random üretilen şekil kodu şeklin içerisine yazılır.

    //Üretilen şeklin ShapeType özelliğine göre uygun nesne çizilir.
    if (shape.ShapeType == "T") {
        ctx.fillText(shape.ShapeCode, shape.ShapeLength / 3, shape.ShapeLength / 3);
        ctx.moveTo(10, 0); //Başlangıç noktası
        ctx.lineTo(10, shape.ShapeLength); 
        ctx.lineTo(shape.ShapeLength, 0);
        ctx.closePath(); //Başlangıç ve bitiş birleştirilir
    }
    else if (shape.ShapeType == "S") {
        ctx.fillText(shape.ShapeCode, shape.ShapeLength / 2, shape.ShapeLength / 2); 
        ctx.rect(10, 10, shape.ShapeLength, shape.ShapeLength); //rect fonksiyonu ile eşit kenarlı çizilerek kare oluşturulur.
    }
    else if (shape.ShapeType == "R") {
        ctx.fillText(shape.ShapeCode, shape.ShapeLength1 / 2, shape.ShapeLength1 / 2);
        ctx.rect(10, 10, shape.ShapeLength2, shape.ShapeLength1);  //rect fonksiyonu ile dikdörtgen oluşturulur.
    }
    ctx.stroke(); 

    $('body').append(canvas); //Oluşturulan canvas body üzerine eklenir.
}

        
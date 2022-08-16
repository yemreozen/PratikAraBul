

function hesapla() {
    //Türkçe
    var tdogru = document.lgshesapla.tdogru.value;
    var tyanlis = document.lgshesapla.tyanlis.value;
    var tnet = Number(tdogru - (tyanlis / 3).toFixed(2));
    document.lgssonuc.tnet.value = tnet;
   //Matematik
    var mdogru = document.lgshesapla.mdogru.value;
    var myanlis = document.lgshesapla.myanlis.value;
    var mnet = Number(mdogru - (myanlis / 3).toFixed(2));
    document.lgssonuc.mnet.value = mnet;
  //İnkılap
    var sdogru = document.lgshesapla.sdogru.value;
    var syanlis = document.lgshesapla.syanlis.value;
    var snet = Number(sdogru - (syanlis / 3).toFixed(2));
    document.lgssonuc.snet.value = snet;
   //Fen
    var fdogru = document.lgshesapla.fdogru.value;
    var fyanlis = document.lgshesapla.fyanlis.value;
    var fnet = Number(fdogru - (fyanlis / 3).toFixed(2));
    document.lgssonuc.fnet.value = fnet;
    //Din
    var dindogru = document.lgshesapla.dindogru.value;
    var dinyanlis = document.lgshesapla.dinyanlis.value;
    var dinnet = Number(dindogru - (dinyanlis / 3).toFixed(2));
    document.lgssonuc.dinnet.value = dinnet;
    //İngilizce
    var ingdogru = document.lgshesapla.ingdogru.value;
    var ingyanlis = document.lgshesapla.ingyanlis.value;
    var ingnet = Number(ingdogru - (ingyanlis / 3).toFixed(2));
    document.lgssonuc.ingnet.value = ingnet;
    //TOPLAM NET VE PUAN
    tpuan = Number(200+ (tnet * 3.45) + (snet * 1.48) + (mnet * 5.79) + (fnet * 3.56) + (dinnet * 1.59) + (ingnet + 1.34)).toFixed(2);
    document.lgssonuc.tpuan.value = tpuan;
    toplamnet = Number(tnet + mnet + fnet + snet + dinnet + ingnet).toFixed(2);
    document.lgssonuc.toplamnet.value = toplamnet;
    //Yüzdelik dilim hesabı

   

}

$(document).ready(function () {
    $("#lgshesaplama").on("keyup", function (event) {
        uyari_mesajlari();
    });
});

var uyari_mesajlari = function () {
    var yirmisoru = $("#yirmisoru").val();
    var onsoru = $("#onsoru").val();

    if (yirmisoru > 20) {
        $(".yirmisoru_uyari").html("Girilen sayı 20'den büyük olmamalıdır.")
    }
    if (onsoru > 10) {
        $(".onsoru_uyari").html("Girilen sayı 10'dan büyük olmamalıdır.")
    }
}



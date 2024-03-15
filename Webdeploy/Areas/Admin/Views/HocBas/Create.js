$(document).ready(function () {
    /*  console.log("Hello World!");*/
    if ($('#list_diemdanhap').val() != "Chưa có dữ liệu") {
        let json_arr = JSON.parse($('#list_diemdanhap').val());
        HienThiDiemDaNhap(json_arr);
    }
    else {
        let output_null = ' <tr><td colspan="11">Chưa có dữ liệu nhập</td></tr>'
        document.getElementById('tdbody_diem').innerHTML = output_null;
    }

});
function HienThiDiemDaNhap(hb_arr) {
    /* console.log(hb_arr);*/
    let _output = "";
    for (let i = 0; i < hb_arr.length; i++) {
        // console.log(hb_arr[i].HocBa_Lop);
        let _lop_hocky = "", _hoc_luc;
        if (hb_arr[i].HocBa_Lop == 11 && hb_arr[i].HocBa_HocKi == 1) { _lop_hocky = "HK 1/Lớp 11" }
        if (hb_arr[i].HocBa_Lop == 11 && hb_arr[i].HocBa_HocKi == 2) { _lop_hocky = "HK 2/Lớp 11" }
        if (hb_arr[i].HocBa_Lop == 12 && hb_arr[i].HocBa_HocKi == 1) { _lop_hocky = "HK 1/Lớp 12" }

        if (hb_arr[i].HocBa_HocLuc == 1) { _hoc_luc = "TB"; }
        if (hb_arr[i].HocBa_HocLuc == 2) { _hoc_luc = "Khá"; }
        if (hb_arr[i].HocBa_HocLuc == 3) { _hoc_luc = "Giỏi"; }

        _output += '<tr>' +
            '<td>' + _lop_hocky + '</td>' +
            '<td>' + _hoc_luc + '</td>' +
            '<td>' + hb_arr[i].HocBa_DiemToan + '</td>' +
            '<td>' + hb_arr[i].HocBa_DiemLi + '</td>' +
            '<td>' + hb_arr[i].HocBa_DiemHoa + '</td>' +
            '<td>' + hb_arr[i].HocBa_DiemSinh + '</td>' +
            '<td>' + hb_arr[i].HocBa_DiemVan + '</td>' +
            '<td>' + hb_arr[i].HocBa_DiemSu + '</td>' +
            '<td>' + hb_arr[i].HocBa_DiemDia + '</td>' +
            '<td>' + hb_arr[i].HocBa_DiemGDCD + '</td>' +
            '<td>' + hb_arr[i].HocBa_DiemAnh + '</td>' +
            '</tr>'
    }
    document.getElementById('tdbody_diem').innerHTML = _output;

}
function NhapDiem() {
    let thiSinh_ID = $('#iDThiSinh').val();
    let selectLopHocKy = $('#select_lop_hocky').find(":selected").val();

    // alert(selectLopHocKy + "/" + selectHocLuc);
    // return;
    let hocBa_Lop = "", hocBa_HocKi = "";
    if (selectLopHocKy == 1) { hocBa_Lop = 11; hocBa_HocKi = 1; }
    if (selectLopHocKy == 2) { hocBa_Lop = 11; hocBa_HocKi = 2; }
    if (selectLopHocKy == 3) { hocBa_Lop = 12; hocBa_HocKi = 1; }

    let hocBa_HocLuc = $('#select_hoc_luc').find(":selected").val();

    let hocBa_DiemToan = $('#hocba_diemToan').val();
    let hocBa_DiemLi = $('#hocba_diemLy').val();
    let hocBa_DiemHoa = $('#hocba_diemHoa').val();
    let hocBa_DiemSinh = $('#hocba_diemSinh').val();
    let hocBa_DiemVan = $('#hocba_diemVan').val();
    let hocBa_DiemSu = $('#hocba_diemSu').val();
    let hocBa_DiemDia = $('#hocba_diemDia').val();
    let hocBa_DiemGDCD = $('#hocba_diemGDCD').val();
    let hocBa_DiemAnh = $('#hocba_diemAnh').val();

    let HocBa_Obj = {
        ThiSinh_ID: thiSinh_ID,
        HocBa_Lop: hocBa_Lop,
        HocBa_HocKi: hocBa_HocKi,
        HocBa_HocLuc: hocBa_HocLuc,
        HocBa_DiemToan: hocBa_DiemToan, HocBa_DiemLi: hocBa_DiemLi, HocBa_DiemHoa: hocBa_DiemHoa, HocBa_DiemSinh: hocBa_DiemSinh,
        HocBa_DiemVan: hocBa_DiemVan, HocBa_DiemSu: hocBa_DiemSu, HocBa_DiemDia: hocBa_DiemDia, HocBa_DiemGDCD: hocBa_DiemGDCD,
        HocBa_DiemAnh: hocBa_DiemAnh,
    };
    //console.log(HocBa_Obj)
    //return;
    $.ajax({
        url: "/HocBas/Update_DiemHocBa",
        data: JSON.stringify(HocBa_Obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            HienThiDiemDaNhap(result)
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function QuayLaiTrangTruoc() {
    let str = "?currentFilter=" + $('#currentFilter_bak').val() +
        "&filteriNganh=" + $('#filteriNganhSort_bak').val() + "&page=" + $('#pageCurren_bak').val();
    window.location.href = "/Admin/HocBas/tsIndex" + str;
}
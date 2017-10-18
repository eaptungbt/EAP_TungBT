using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService_ASM_TungBT
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BankingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BankingService.svc or BankingService.svc.cs at the Solution Explorer and start debugging.
    public class BankingService : IBankingService
    {
        ServiceDatabaseDataContext data = new ServiceDatabaseDataContext();

        public List<GiaoDich> LichSuKhachHang(KhachHang khachHang, DateTime fromDate, DateTime todate)
        {
            var ls = data.GiaoDiches.Where(gd => ((gd.maKH==khachHang.maKH)&&(gd.thoiGian >= fromDate)&&(gd.thoiGian <= todate))).ToList();
            return ls;
        }
        public List<GiaoDich> LichSuDoiTac(DoiTac doiTac, DateTime fromDate, DateTime todate)
        {
            var ls = data.GiaoDiches.Where(gd => ((gd.maDoiTac == doiTac.maDoiTac) && (gd.thoiGian >= fromDate) && (gd.thoiGian <= todate))).ToList();
            return ls;
        }

        public string ThanhToan(DoiTac doiTac, KhachHang khachHang, decimal soTien, int hthuc)
        {
            if (checkDT(doiTac))
            {
                if (checkKH(khachHang))
                {
                    //khi ca 2 tai khoan doi tac va khach hang TRUE

                    //hthuc == 1 ----> KHACHHANG tra tien co DOITAC
                    //hthuc != 1 ----> DOITAC tra tien co KHACHHANG
                    if (hthuc == 1)
                    {
                        if (checkSoDu(soTien, khachHang))
                        {
                            //du tat ca cac dieu kien
                            //xu ly tien
                            Congtien(doiTac, soTien);
                            TruTien(khachHang, soTien);
                            //luu vao ls
                            string createMAGD = "GD_" +khachHang.maKH.ToUpper()+"_"+ DateTime.Now.ToString();
                            string createTENGD = khachHang.maKH.ToUpper() + "pay" + doiTac.maDoiTac.ToUpper() + "_" + DateTime.Now.ToString();
                            ghiGD(createMAGD,createTENGD,khachHang,doiTac,soTien,hthuc);
                            return "Thành Công";
                        }
                        else
                        {
                            return "Không đủ số dư để thực hiện giao dịch";
                        }
                    }else 
                    {
                        //
                        if (checkSoDu(soTien, doiTac))
                        {
                            Congtien(khachHang, soTien);
                            TruTien(doiTac, soTien);

                            string createMAGD = "GD_" + doiTac.maDoiTac.ToUpper() + DateTime.Now.ToString();
                            string createTENGD = doiTac.maDoiTac + " pay " + khachHang.maKH;
                            ghiGD(createMAGD, createTENGD, khachHang, doiTac, soTien, hthuc);
                            return "Thành Công";
                        }
                        else {
                            return "Chưa thể thực hiện.";
                        }
                    }
                }
                else {
                    //khach hang falses
                    return "Khách hàng không hợp lệ";
                }
            }
            else {
                //Doi tac false
                return "Ngân hàng không hỗ trợ dịch trên trang WEB này";
            }
        }

        public decimal getSoDuKhachHang(KhachHang khachHang)
        {
            var rt = data.KhachHangs.Where(kh => kh.maKH==khachHang.maKH).FirstOrDefault();
            return rt.soDu;
        }
        public decimal getSoDuDoiTac(DoiTac doiTac)
        {
            var rt = data.DoiTacs.Where(dt => dt.maDoiTac==doiTac.maDoiTac).FirstOrDefault();
            return rt.soDu;
        }

        private void Congtien(KhachHang kh,decimal sotien) {
            var khachHang = data.KhachHangs.Where(k => k.maKH==kh.maKH).FirstOrDefault();
            khachHang.soDu += (sotien - tinhPhi(sotien));
            data.SubmitChanges();
        }
        private void Congtien(DoiTac dt, decimal sotien)
        {
            var doiTac = data.DoiTacs.Where(d => d.maDoiTac == dt.maDoiTac).FirstOrDefault();
            doiTac.soDu += (sotien - tinhPhi(sotien));
            data.SubmitChanges();
        }
        private void TruTien(KhachHang kh, decimal sotien)
        {
            var khachHang = data.KhachHangs.Where(k => k.maKH == kh.maKH).FirstOrDefault();
            khachHang.soDu -= (sotien);
            data.SubmitChanges();
        }
        private void TruTien(DoiTac dt, decimal sotien)
        {
            var doiTac = data.DoiTacs.Where(d => d.maDoiTac == dt.maDoiTac).FirstOrDefault();
            doiTac.soDu -= (sotien);
            data.SubmitChanges();
        }

        private void ghiGD(string createMAGD,string createTENGD, KhachHang kh,DoiTac dt,decimal tien,int hthuc) {
            var giaoDich = new GiaoDich()
            {
                maGD = createMAGD,
                maKH = kh.maKH,
                maDoiTac = dt.maDoiTac,
                soTien = tien,
                tenGD = createTENGD,
                loai = hthuc,
                thoiGian = DateTime.Now,
                phiGD = tinhPhi(tien)
            };
            data.GiaoDiches.InsertOnSubmit(giaoDich);
            data.SubmitChanges();
        }
        private decimal tinhPhi(decimal tien) {
            if (tien <= 100000)
            {
                return 10000;
            }
            else if (tien > 100000 && tien <= 500000)
            {
                return ((tien * 2) / 100);
            }
            else if (tien > 500000 && tien <= 1000000)
            {
                return ((tien * 15) / 1000);
            }
            else if (tien > 1000000 && tien <= 5000000)
            {
                return ((tien) / 100);
            }
            else {
                return ((tien * 5) / 1000);
            }
            }

        private bool checkDT(DoiTac dtac) {
            var rt = data.DoiTacs.Where(dt => dt.maDoiTac == dtac.maDoiTac && dt.matKhau == dtac.matKhau).FirstOrDefault();
            if (rt == null)
            {
                return false;
            }
            else {
                return true;
            }
        }
        private bool checkKH(KhachHang khachHang)
        {
            var rt = data.KhachHangs.Where(kh => kh.maKH == khachHang.maKH && kh.pin == khachHang.pin).FirstOrDefault();
            if (rt == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkSoDu(decimal sotien, KhachHang kh) {
            KhachHang khackHang = data.KhachHangs.Where(khang => khang.maKH==kh.maKH && khang.pin==kh.pin).FirstOrDefault();
            if (sotien < (khackHang.soDu - 50000))
            {
                return true;
            }
            return false;
        }
        private bool checkSoDu(decimal sotien, DoiTac dt)
        {
            if (sotien < (dt.soDu-50000))
            {
                return true;
            }
            return false;
        }
    }
}

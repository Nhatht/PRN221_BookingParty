using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService;

namespace PRN221_GroupProjectBookParty.Pages.Admin.Dashboard
{
    public class DashboardModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly IAccountService _accountService;
        private readonly IPartysService _partysService;
        public DashboardModel(IBookingService bookingService, IAccountService accountService, IPartysService partysService)
        {
            _bookingService = bookingService;
            _accountService = accountService;
            _partysService = partysService;
        }

        public void OnGet()
        {
            Dictionary<int, decimal> dataYearNow = new Dictionary<int, decimal>();
            Dictionary<int, decimal> dataLastYear = new Dictionary<int, decimal>();
            DateTime currentDate = DateTime.Now;
            int M = 10;
            int yearNow = currentDate.Year;
            int lastYear = yearNow - 1;
            decimal totalRevenueYearNow = 0;
            decimal totalRevenueLastYear = 0;
            decimal totalRevenue = 0;
            Booking booking = new Booking();
            List<Booking> listRevenue = _bookingService.GetPayment();
            

            foreach (Booking payment in listRevenue)
            {
                int paymentYear = payment.StartDate.Year;
                int paymentMonth = payment.StartDate.Month;
                decimal paymentPrice = payment.TotalPrice;
                
                if (paymentYear == yearNow)
                {
                    totalRevenueYearNow += paymentPrice;
                    dataYearNow[paymentMonth] = dataYearNow.ContainsKey(paymentMonth) ? dataYearNow[paymentMonth] + paymentPrice : paymentPrice;
                   
                }
                if (paymentYear == lastYear)
                {
                    totalRevenueLastYear += paymentPrice;
                    dataLastYear[paymentMonth] = dataLastYear.ContainsKey(paymentMonth) ? dataLastYear[paymentMonth] + paymentPrice : paymentPrice;
                }
                totalRevenue += paymentPrice;
             }
            List<int> dataYearNowList = new List<int>();
            List<int> dataLastYearList = new List<int>();

            for (int month = 1; month <= 12; month++)
            {
                decimal dataYearNowValueDecimal = dataYearNow.ContainsKey(month) ? dataYearNow[month] : 0m;
                int dataYearNowValue = (int)Math.Round(dataYearNowValueDecimal / M);

                decimal dataLastYearValueDecimal = dataLastYear.ContainsKey(month) ? dataLastYear[month] : 0m;
                int dataLastYearValue = -(int)Math.Round(dataLastYearValueDecimal / M);

                dataYearNowList.Add(dataYearNowValue);
                dataLastYearList.Add(dataLastYearValue);
            }
            ViewData["TotalRevenueYearNow"] = Math.Round(totalRevenueYearNow) / M;
            ViewData["TotalRevenueLastYear"] = Math.Round(totalRevenueLastYear) / M;
            ViewData["TotalRevenue"] = Math.Round(totalRevenue) / M;
            ViewData["YearNow"] = yearNow;
            ViewData["LastYear"] = lastYear;
            //ViewData["Years"] = years;
            ViewData["ListRevenue"] = listRevenue;
            ViewData["DataYearNow"] = dataYearNowList;
            ViewData["DataLastYear"] = dataLastYearList;
            List<Account> user = _accountService.GetAccountByRole("User");
            int countuser = user.Count;
            List<Account> host = _accountService.GetAccountByRole("Host");
            int countbooking = listRevenue.Count;
            int counthost = host.Count;
            List<BookingRevenue> hostRevenue = _bookingService.GetRevenueHost(yearNow);
            foreach (var item in hostRevenue)
            {               
                item.TotalRevenue = Math.Round(item.TotalRevenue) / M;
                // Sử dụng các giá trị hostId, hostName, và totalRevenue ở đây
            }            
            ViewData["HostRevenue"] = hostRevenue;
            ViewData["user"] = countuser;
            ViewData["host"] = counthost;
            ViewData["booking"] = countbooking;

        }
    }
}

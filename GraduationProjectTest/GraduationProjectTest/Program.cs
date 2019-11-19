using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Configuration;

namespace GraduationProjectTest
{
    static class Program
    {
        public static sallary xsallary;
        public static monthlyinventory xminventory;
        public static yearlyinventory xyinventory;
        public static SqlConnection xdata;
        public static string xsource;
        public static Billinglist xblist;
        public static Billview xbview;
        public static delivery xdelivery;
        public static manager_password xmanagpass;
        public static changepass xchangepass;
        public static Insertquantity xqantity;
        public static showsuggestedoffers xsgg;
        public static addcustomer xaddcus ;
        public static Addemployee xaddemp ;
        public static additem xadditem ;
        public static Cash xcash ;
        public static dailysales xdaily;
        public static cashkeybourd xcashkeyb ;
        public static changemenuname xchangmenu ;
        public static changebuttonname xchangbtn ;
        public static Destroyitems xdestroy ;
        public static discount xdiscount ;
        public static editcustomer xeditcus ;
        public static Editemployee xeditemp ;
        public static Edititem xedititem ;
        public static Help xhelp ;
        public static insertpassword xpassword ;
        public static makeoffer xmakeoffer;
        public static availableoffers xavaoffer;
        public static monthlyprofit xmprofit;
        public static yearlyprofit xyprofit;
        public static Login xlogin ;
        public static manager xmanager ;
        public static Showemployee xshowemp ;
        public static deleteemp xdeleteemp;
        public static deleteitem xdeleteitem;
        public static manchangepass xmanpassch;
        public static Maps xmaps;
        public static tabels xtabel;
        public static BuyItem xbuyl;
        public static employeeswithdraw xemoloyeewithdraw;
        public static viewavaitems xviewava;
        public static viewspecitem xviewspec;
        public static mandailysales xmandaily;
        public static mansalesspecperiod xmanspec;
        public static salesforspecitem xsalesspec;
        public static manamonthlysales xmanmonth;
        public static manyearlysales xmanyear;
        public static manbuyinglist xmanbuy;
        public static manbuyspec xmanbuyspec;
        public static insertexpenses xinexpenses;
        public static viewexpenses xvexpenses;
        public static closingcash xclose;
        public static mesage xmsg;
        public static offers xoffer;
        public static Boolean closecashe;
        public static salesChart xsalesChart;
        public static netProfitChart xnetProfit;
        public static DeliveryChart xdeliveryChart;



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
             string[] arguments = Environment.GetCommandLineArgs();
                                if (arguments.GetUpperBound(0) > 0)
                                {
                                        foreach (string argument in arguments)
                                        {
                                                if (argument.Split('=')[0].ToLower().Equals("/u"))
                                                {
                                                        string guid = argument.Split('=')[1];
                                                        string path = Environment.GetFolderPath(Environment.SpecialFolder.System);
                                                        var si = new ProcessStartInfo(path + "\\msiexec.exe", "/x" + guid);
                                                        Process.Start(si);
                                                        Application.Exit();
                                                }
                                        }
                                        //end of upgrade
                                }
                                else
                                {
                                        bool onlyInstance = false;
                                        var mutex = new Mutex(true, Application.ProductName, out onlyInstance);
                                        if (!onlyInstance)
                                        {
                                                MessageBox.Show("Another copy of this running");
                                                return;
                                        }
                                        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                                        Application.ThreadException += ApplicationThreadException;
                                        Application.EnableVisualStyles();
                                        Application.SetCompatibleTextRenderingDefault(false);
                                        xaddcus = new addcustomer();
                                        xaddemp = new Addemployee();
                                        xadditem = new additem();
                                        xdata = new System.Data.SqlClient.SqlConnection();
                                        xdata.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\amjad\UW-BOOTCAMP\Smart-Inventory-System\GraduationProjectTest\GraduationProjectTest\Database1.mdf;Integrated Security=True;Connect Timeout=30";
                                    xcash = new Cash();
                                        xcashkeyb = new cashkeybourd();
                                        closecashe = false;
                                        xchangmenu = new changemenuname();
                                        xdestroy = new Destroyitems();
                                        xoffer = new offers();
                                        xblist = new Billinglist();
                                        xsgg = new showsuggestedoffers();
                                        xbview = new Billview();
                                        xclose = new closingcash();
                                        xmsg = new mesage();
                                        xmprofit = new monthlyprofit();
                                        xyprofit = new yearlyprofit();
                                        xdiscount=new discount();
                                        xsallary = new sallary();
                                        xmanpassch = new manchangepass();
                                        xminventory = new monthlyinventory();
                                        xyinventory = new yearlyinventory();
                                        xemoloyeewithdraw = new employeeswithdraw();
                                        xchangepass = new changepass();
                                        xeditcus = new editcustomer();
                                        xmanagpass = new manager_password();
                                        xbuyl = new BuyItem();
                                        xeditemp = new Editemployee();
                                        xinexpenses = new insertexpenses();
                                        xvexpenses = new viewexpenses();
                                        xdaily = new dailysales();
                                        xqantity = new Insertquantity();
                                        xedititem = new Edititem();
                                        xhelp = new Help();
                                        xlogin = new Login();
                                        xmanager = new manager();
                                        xdelivery = new delivery();
                                        xpassword = new insertpassword();
                                        xtabel = new tabels();
                                        xshowemp = new Showemployee();
                                        xsource = @" Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\amjad\UW-BOOTCAMP\Smart-Inventory-System\GraduationProjectTest\GraduationProjectTest\Database1.mdf;Integrated Security=True;Connect Timeout=30";
                                        xdeleteemp = new deleteemp();
                                        xdeleteitem = new deleteitem();
                                        xmakeoffer = new makeoffer();
                                        xavaoffer = new availableoffers();
                                        xmaps = new Maps();
                                        xviewava = new viewavaitems();
                                        xviewspec = new viewspecitem();
                                        xmandaily = new mandailysales();
                                        xmanspec = new mansalesspecperiod();
                                        xsalesspec = new salesforspecitem();
                                        xmanmonth = new manamonthlysales();
                                        xmanyear = new manyearlysales();
                                        xmanbuy = new manbuyinglist();
                                        xmanbuyspec = new manbuyspec();
                                        xsalesChart = new salesChart();
                                        xnetProfit = new netProfitChart();
                                        xdeliveryChart = new DeliveryChart();
                                        Application.Run(new Form1());
                                }
                        }

                        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
                        {
                                try
                                {
                                        var ex = (Exception) e.ExceptionObject;
                                        MessageBox.Show("Whoops! Please contact the developers with the following"
                                                                        + " information:\n\n" + ex.Message + ex.StackTrace,
                                                                        " Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                catch (Exception)
                                {
                                        //do nothing - Another Exception! Wow not a good thing.
                                }
                                finally
                                {
                                        Application.Exit();
                                }
                        }

                        public static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
                        {
                                try
                                {
                                        MessageBox.Show("Whoops! Please contact the developers with the following"
                                                                        + " information:\n\n" + e.Exception.Message + e.Exception.StackTrace,
                                                                        " Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                catch (Exception)
                                {
                                        //do nothing - Another Exception! Wow not a good thing.
                                }
                        }
                }
        }
        
    
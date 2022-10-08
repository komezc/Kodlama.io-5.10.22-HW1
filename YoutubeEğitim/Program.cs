using System.Runtime.CompilerServices;
using System.Threading.Tasks.Sources;

namespace YoutubeEğitim
{
   class Program {
      static void Main(string[] args) {


            //Ioc Container
            CustomerManager customerManager = new CustomerManager(new Customer(), new TeacherCreditManager());
            customerManager.GiveCredit();



            Console.ReadLine();

      }
   }
    //SOLID

    class CreditManager {
      public void Calculate(int creditType){

            if (creditType == 1) //esnaf
            {

            }

            if (creditType == 2) //ogretmen
            {

            }
        Console.WriteLine("Hesaplandi");
      }   
      public void Save() {
        Console.WriteLine("Kredi verildi");
      }
    }

    interface ICreditManager
    {
        void Calculate();
        void Save();
    }

    abstract class BaseCreditManager : ICreditManager
    {
        public abstract void Calculate();

        public virtual void Save()
        {
            Console.WriteLine("kaydedildi");
        }
    }
    
    class TeacherCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            //hesaplamalar
            Console.WriteLine("Ogretmen kredisi hesaplandi");
        }

        public override void Save()
        {
            base.Save();
        }

    }

    class MilitaryCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Asker kredisi hesaplandi");
        }

    }
    class CarCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Araba kredisi hesaplandi");
        }

    }



    class Customer
    {
        public Customer()
        {
            Console.WriteLine("Musteri nesnesi baslatildi");
        }
        public int Id { get; set; }
        
        public string City { get; set; }

    }

    class Person : Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
    }

    class Company : Customer 
    {
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
    }



    //Katmanli mimari
    class CustomerManager
    {
        private Customer _customer;
        private ICreditManager _creditManager;
        public CustomerManager(Customer customer, ICreditManager creditManager)
        {
            _customer = customer;
            _creditManager = creditManager;
        }
        public void Save()
        {
            Console.WriteLine("Musteri kaydedildi : ");
        }
        public void Delete()
        {
            Console.WriteLine("Musteri silindi : ");
        }

        public void GiveCredit()
        {
            _creditManager.Calculate();
            Console.WriteLine("Kredi verildi");
        }
    }

}
/*
            CreditManager creditManager = new CreditManager();
            creditManager.Calculate();
            creditManager.Calculate();
            creditManager.Save();


            Customer customer= new Customer();  //ornegini olusturmak ya da instance olusturmak(instance creation), icin newliyoruz.heap da referans numarasi olusturuyoruz.
            customer.Id = 1;
            customer.City = "Ankara";

            CustomerManager customerManager = new CustomerManager(customer);
            customerManager.Save();
            customerManager.Delete();

            Company company= new Company();
            company.TaxNumber = "100000";
            company.CompanyName = "Arcelik";
            company.Id = 100;


            CustomerManager customerManager2 = new CustomerManager(new Person());


            Person person=new Person();
            person.NationalIdentity = "";
            person.FirstName = "";

            Customer c1 = new Customer();
            Customer c2 = new Person();
            Customer c3 = new Company();
            /*

            Console.ReadLine();

         /*
         int[] sayilar1 = new[] { 1, 2, 3 };
         int[] sayilar2 = new[] { 10, 20, 30 };

         sayilar1 = sayilar2;

         sayilar1[0] = 51000;

         sayilar2[0] = 1000;

         Console.WriteLine(sayilar1[0]);

         int sayi1=10;
         int sayi2 = 20;
         sayi1 = sayi2;
         sayi2 = 100;

         Console.WriteLine(sayi1);
          */
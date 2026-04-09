using SWT281_XUnitTesting;
using System.Text;
using System.Xml.Linq;

namespace SWT281_XUnitTesting
{
    #region UserLoginTest
    public class UserLoginTest
    {
        private string name, password;

        private HashSet<(string, string)> uniqueStorage = new HashSet<(string, string)>() { ("Test", "123") };

        public HashSet<(string, string)> UniqueStorage
        {
            get { return uniqueStorage; }//Read
            set { uniqueStorage = value ?? new HashSet<(string, string)>(); }//Write
        }
        public bool displayLogin(string InName, string InPassword)
        {
            bool found = false;
            int i = 3;
            do
            {
                name = InName;
                password = InPassword;

                foreach (var store in UniqueStorage)
                {
                    if (store.Item1 == name && store.Item2 == password)
                    {
                        found = true;
                        break;
                    }
                }

                if (found == true)
                {
                    return true;
                }
                else
                {
                    i--;
                }
                if (i == 0)
                {
                    return false;
                }
            }
            while (found == false);
            return false;
        }

        [Fact]
        public void Test1()
        {
            //Arrange
            bool result;
            //Act
            result = displayLogin("Test", "123");
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {
            //Arrange
            bool result;
            //Act
            result = displayLogin("Tesgrerherh", "123");
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Test3()
        {
            //Arrange
            bool result;
            //Act
            result = displayLogin("Test", "123fwewfefwe");
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Test4()
        {
            //Arrange
            bool result;
            //Act
            result = displayLogin("Tesgrerherh", "123fwewfefwe");
            //Assert
            Assert.True(result);
        }
    }
    #endregion

    #region ViewAnimalClasses
    public class Owner
    {
        private string ownerName;
        private int ownerID;
        private int ownerCoverageNr;
        private string ownerCoverageName;
        private string ownerCoveragePackage;

        public Owner(string ownerName, int ownerID, int ownerCoverageNr, string ownerCoverageName, string ownerCoveragePackage) 
        { 
            this.ownerName = ownerName;
            this.ownerID = ownerID;
            this.ownerCoverageNr = ownerCoverageNr;
            this.ownerCoverageName = ownerCoverageName;
            this.ownerCoveragePackage = ownerCoveragePackage;
        }
    }
    public class Animal:Owner
    {
        private string animalName;
        private int animalAge;
        private double animalWeight; 
        private int animalID;
        private string animalGender;
        private string dietType;
        private double dosage;

        public Animal(string ownerName, int ownerID, int ownerCoverageNr, string ownerCoverageName, string ownerCoveragePackage, string animalName, int animalAge, double animalWeight, int animalID, string animalGender, string dietType)
            : base(ownerName, ownerID, ownerCoverageNr, ownerCoverageName, ownerCoveragePackage)
        {
            this.animalName = animalName;
            this.animalAge = animalAge;
            this.animalWeight = animalWeight;
            this.animalID = animalID;
            this.animalGender = animalGender;
            this.dietType = dietType;
        }
    }

    public class Mammals: Animal
    {
        private string furType;
        private int legCount;
        public Mammals(string ownerName, int ownerID, int ownerCoverageNr, string ownerCoverageName, string ownerCoveragePackage, string animalName, int animalAge, double animalWeight, int animalID, string animalGender, string dietType, string furType, int legCount)
            : base(ownerName, ownerID, ownerCoverageNr, ownerCoverageName, ownerCoveragePackage, animalName, animalAge, animalWeight, animalID, animalGender, dietType)
        {
            this.furType = furType;
            this.legCount = legCount;

        }
    }
    public class Birds: Animal
    {
        private double wingSpan;

        public Birds(string ownerName, int ownerID, int ownerCoverageNr, string ownerCoverageName, string ownerCoveragePackage, string animalName, int animalAge, double animalWeight, int animalID, string animalGender, string dietType, double wingSpan)
            : base(ownerName, ownerID, ownerCoverageNr, ownerCoverageName, ownerCoveragePackage, animalName, animalAge, animalWeight, animalID, animalGender, dietType)
        {
            this.wingSpan = wingSpan;
        }
    }
    public class Reptiles: Animal
    {
        private string scaleType;

        public Reptiles(string ownerName, int ownerID, int ownerCoverageNr, string ownerCoverageName, string ownerCoveragePackage, string animalName, int animalAge, double animalWeight, int animalID, string animalGender, string dietType, string scaleType)
            : base(ownerName, ownerID, ownerCoverageNr, ownerCoverageName, ownerCoveragePackage, animalName, animalAge, animalWeight, animalID, animalGender, dietType)
        {
            this.scaleType = scaleType;
        }
    }
    public class WaterAnimals: Animal
    {
        private int gilCount;
        private int finCount;

        public WaterAnimals(string ownerName, int ownerID, int ownerCoverageNr, string ownerCoverageName, string ownerCoveragePackage, string animalName, int animalAge, double animalWeight, int animalID, string animalGender, string dietType, int gilCount, int finCount)
            : base(ownerName, ownerID, ownerCoverageNr, ownerCoverageName, ownerCoveragePackage, animalName, animalAge, animalWeight, animalID, animalGender, dietType)
        {
            this.gilCount = gilCount;
            this.finCount = finCount;
        }
    }
    #endregion

    #region ViewAnimalsTest
    enum displayAnimalOwner
    {
        Display_Animal,
        Display_Owner
    }
    public class ViewAnimalsTest
    {
        private static IList<Owner> ownerList = new List<Owner>()
        {
        };
        private static IList<Animal> animalList = new List<Animal>()
        {
        };
        public string ViewAnimals(int choice)
        {
            displayAnimalOwner ViewChoice = (displayAnimalOwner)(choice);
            switch (ViewChoice)
            {
                case displayAnimalOwner.Display_Animal:
                    if (animalList.Count == 0)
                    {
                        return "No Animal";
                    }
                    else
                    {
                        foreach (var animal in animalList)
                        {
                            if (animal is Mammals mammal)
                            {
                                return "Mammal";
                            }
                            else if (animal is Reptiles reptile)
                            {
                                return "Reptile";
                            }
                            else if (animal is Birds bird)
                            {
                                return "Bird";
                            }
                            else if (animal is WaterAnimals wateranimal)
                            {
                                return "WaterAnimal";
                            }

                        }
                    }
                    break;
                case displayAnimalOwner.Display_Owner:
                    if (ownerList.Count == 0)
                    {
                        return "No Owner";
                    }
                    else
                    {
                        return "Owner";
                    }
                default:
                    return "Fail";
            }
            return "Outside Switch";
        }
        [Fact]
        public void TestViewInvalidInput()
        {
            //Arrange
            int input;
            //Act
            input = 2;
            string tester = ViewAnimals(input);
            //Assert
            Assert.Equal("Failed", tester);
        }
        [Fact]
        public void TestViewEmptyOwner()
        {
            //Arrange
            int input;
            //Act
            ownerList.Clear();
            input = 1;
            string tester = ViewAnimals(input);
            //Assert
            Assert.Equal("Owner", tester);
        }
        [Fact]
        public void TestViewOwner()
        {
            //Arrange
            int input;
            //Act
            input = 1;
            ownerList.Add(new Owner("Ben", 12, 1234, "Outsurance", "Deluxe package"));
            string tester = ViewAnimals(input);
            //Assert
            Assert.Equal("Owner", tester);
        }

        [Fact]
        public void TestViewEmptyAnimal()
        {
            //Arrange
            int input;
            //Act
            animalList.Clear();
            input = 0;
            string tester = ViewAnimals(input);
            //Assert
            Assert.Equal("No Animal", tester);
        }
        [Fact]
        public void TestViewMammals()
        {
            //Arrange
            int input;
            //Act
            animalList.Clear();
            animalList.Add(new Mammals("Ben", 12, 1234, "Outsurance", "Deluxe package", "Spotty", 12, 30, 1, "Male", "Omnivore", "Fluffy", 4));
            input = 0;
            string tester = ViewAnimals(input);
            //Assert
            Assert.Equal("Mammals", tester);
        }
        [Fact]
        public void TestViewBirds()
        {
            //Arrange
            int input;
            //Act
            animalList.Clear();
            animalList.Add(new Birds("Ben",12,1234,"Outsurance","Deluxe package","PietMyVrou",1,1,2,"Male","Omnivore",40));
            input = 0;
            string tester = ViewAnimals(input);
            //Assert
            Assert.Equal("Birds", tester);
        }
        [Fact]
        public void TestViewReptile()
        {
            //Arrange
            int input;
            //Act
            animalList.Clear();
            animalList.Add(new Reptiles("Ben",12,1234,"Outsurance","Deluxe package","Jandre",19,70,3,"Thing","Eats everything","Prickly"));
            input = 0;
            string tester = ViewAnimals(input);
            //Assert
            Assert.Equal("Reptiles", tester);
        }
        [Fact]
        public void TestViewWaterAnimal()
        {
            //Arrange
            int input;
            //Act
            animalList.Clear();
            animalList.Add(new WaterAnimals("Ben",12,1234,"Outsurance","Deluxe package","Eduard",20000,60,4,"Male sometimes","Omnivore",1,2));
            input = 0;
            string tester = ViewAnimals(input);
            //Assert
            Assert.Equal("Water", tester);
        }
    }
    #endregion

    #region MainMenu

    public enum main_Menu
    {
        Add_Animal = 0,
        View_All_Animals,
        Search_Animal,
        View_Med_Inventory,
        Calc_Med_Dosage,
        Add_Employee,
        Add_Login,
        Manage_Appointments,
        Calc_Emp_Salary,
        Exit_Program
    }


    public class MenuController
    {
        private readonly IMenuActions myActions;
        private readonly IConsoleService myConsole;

        //Links the MenuController to the actions and console services
        public MenuController(IMenuActions actions, IConsoleService console)
        {
            myActions = actions;
            myConsole = console;
        }

        // Handles the menu choice and returns true to continue or false to exit
        public bool Handle(main_Menu choice, IUserLogin? userLogin = null)
        {
            switch (choice)
            {
                case main_Menu.Add_Animal:
                    myConsole.Clear();
                    myConsole.CursorVisible = true;
                    myActions.AddAnimal();
                    return true;

                case main_Menu.View_All_Animals:
                    myConsole.Clear();
                    myActions.ViewAnimals();
                    return true;

                case main_Menu.Search_Animal:
                    myConsole.Clear();
                    myActions.SearchAnimal();
                    return true;

                case main_Menu.View_Med_Inventory:
                    myConsole.Clear();
                    myActions.MedsInventory();
                    return true;

                case main_Menu.Calc_Med_Dosage:
                    myConsole.Clear();
                    myActions.CalculateDosage();
                    return true;

                case main_Menu.Add_Employee:
                    myConsole.Clear();
                    myActions.AddEmployee();
                    return true;

                case main_Menu.Add_Login:
                    if (userLogin is null)
                        throw new ArgumentNullException(nameof(userLogin), "User login required for Add_Login");
                    myActions.AddLogin(userLogin);
                    myConsole.Clear();
                    userLogin.DisplayLogin();
                    return true;

                case main_Menu.Manage_Appointments:
                    myConsole.Clear();
                    myActions.ManageAppointment();
                    return true;

                case main_Menu.Calc_Emp_Salary:
                    myConsole.Clear();
                    myActions.CalcEmpSalary();
                    return true;

                case main_Menu.Exit_Program:
                    myActions.ExitProgram();
                    return false;

                default:
                    return true;
            }
        }
    }

    // Interface to abstract MenuMethods for testing
    public interface IMenuActions
    {
        void AddAnimal();
        void ViewAnimals();
        void SearchAnimal();
        void MedsInventory();
        void CalculateDosage();
        void AddEmployee();
        void AddLogin(IUserLogin userLogin);
        void ManageAppointment();
        void CalcEmpSalary();
        void ExitProgram();
    }

    // Interface to abstract UserLogin for testing
    public interface IUserLogin
    {
        void DisplayLogin();
    }

    // Interface to abstract Console methods for testing
    public interface IConsoleService
    {
        void Clear();
        bool CursorVisible { get; set; }
    }


    //Simulates our main program's Console testing
    file class FakeConsole : IConsoleService
    {
        public int ClearCount { get; private set; }
        public bool CursorVisible { get; set; }
        public List<string> Events { get; } = new();

        public void Clear()
        {
            ClearCount++;
            Events.Add("Console.Clear");
        }
    }

    //Simulates our main program's UserLogin for testing
    file class FakeUserLogin : IUserLogin
    {
        public int DisplayCount { get; private set; }
        public List<string> Events { get; } = new();

        public void DisplayLogin()
        {
            DisplayCount++;
            Events.Add("UserLogin.DisplayLogin");
        }
    }

    //Simulates our main program's MenuMethods for testing
    file class FakeActions : IMenuActions
    {
        public List<string> Calls { get; } = new();

        public void AddAnimal() => Calls.Add(nameof(AddAnimal));
        public void ViewAnimals() => Calls.Add(nameof(ViewAnimals));
        public void SearchAnimal() => Calls.Add(nameof(SearchAnimal));
        public void MedsInventory() => Calls.Add(nameof(MedsInventory));
        public void CalculateDosage() => Calls.Add(nameof(CalculateDosage));
        public void AddEmployee() => Calls.Add(nameof(AddEmployee));
        public void AddLogin(IUserLogin userLogin) => Calls.Add(nameof(AddLogin));
        public void ManageAppointment() => Calls.Add(nameof(ManageAppointment));
        public void CalcEmpSalary() => Calls.Add(nameof(CalcEmpSalary));
        public void ExitProgram() => Calls.Add(nameof(ExitProgram));
    }

    public class MenuControllerTests
    {
        //Tests that Add_Animal clears the console, sets cursor visible, invokes AddAnimal, and continues the program
        [Fact]
        public void AddAnimal_ClearsConsole_SetsCursorVisible_InvokesAddAnimal_Continues()
        {
            var actions = new FakeActions();
            var console = new FakeConsole();
            var sut = new MenuController(actions, console);

            var cont = sut.Handle(main_Menu.Add_Animal);

            Assert.True(cont);
            Assert.Equal(1, console.ClearCount);
            Assert.True(console.CursorVisible);
            Assert.Collection(actions.Calls, c => Assert.Equal("AddAnimal", c));
        }

        [Theory]
        [InlineData(main_Menu.View_All_Animals, "ViewAnimals")]
        [InlineData(main_Menu.Search_Animal, "SearchAnimal")]
        [InlineData(main_Menu.View_Med_Inventory, "MedsInventory")]
        [InlineData(main_Menu.Calc_Med_Dosage, "CalculateDosage")]
        [InlineData(main_Menu.Add_Employee, "AddEmployee")]
        [InlineData(main_Menu.Manage_Appointments, "ManageAppointment")]
        [InlineData(main_Menu.Calc_Emp_Salary, "CalcEmpSalary")]

        //Tests that these options clear the console, invoke the correct action, and continue the program
        public void NonLoginNonExitOptions_ClearConsole_InvokeCorrectAction_Continue(main_Menu choice, string expectedCall)
        {
            var actions = new FakeActions();
            var console = new FakeConsole();
            var sut = new MenuController(actions, console);

            var cont = sut.Handle(choice);

            Assert.True(cont);
            Assert.Equal(1, console.ClearCount);
            Assert.Collection(actions.Calls, c => Assert.Equal(expectedCall, c));
        }


        //Tests that Exit_Program does not clear the console, calls ExitProgram, and stops the program
        [Fact]
        public void ExitProgram_DoesNotClearConsole_CallsExit_ReturnsFalse()
        {
            var actions = new FakeActions();
            var console = new FakeConsole();
            var sut = new MenuController(actions, console);

            var cont = sut.Handle(main_Menu.Exit_Program);

            Assert.False(cont);
            Assert.Equal(0, console.ClearCount);
            Assert.Collection(actions.Calls, c => Assert.Equal("ExitProgram", c));
        }
    }

    #endregion
}
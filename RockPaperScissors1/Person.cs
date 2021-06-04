namespace RockPaperScissors1
{
    public class Person
    {
        public string fname{get; set;}
        public string lname{get; set;}
        public string myCountry{get; set;}

        public Person(){
            fname = "defaultFName";
            lname = "defaultLName";
        }

        public Person(string fname, string lname){
            this.fname = fname;
            this.lname = lname;
        }
    }
}
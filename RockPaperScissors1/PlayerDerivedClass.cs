namespace RockPaperScissors1
{
    public class PlayerDerivedClass : Person
    {
        public PlayerDerivedClass(){
            this.fname = "derivedClassfname";
            this.lname = "derviedClasslname";
        }

        public PlayerDerivedClass(string fname, string lname){
            this.fname = fname;
            this.lname = lname;
        }
    }
}
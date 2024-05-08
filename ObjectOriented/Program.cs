internal class Program
{
    static void Main(string[] args)
    {
        Patient patient = new Patient();
        patient.name = "John Doe";
        patient.DOB = "01/01/1999";
        patient.patientID = 5;
        patient.DisplayPersonInfo();
        Console.WriteLine("----------------------");

        Admin admin = new Admin();
        admin.name = "Feb Aguilar";
        admin.DOB = "02/05/1961";
        admin.staffID = 1011;
        admin.reportsTo = "President Myers";
        admin.DisplayPersonInfo();
        Console.WriteLine("----------------------");

        Nurse nurse = new Nurse();
        nurse.name = "Mar Sisa";
        nurse.DOB = "03/21/1987";
        nurse.staffID = 1213;
        nurse.shifts = "MWF";
        nurse.DisplayPersonInfo();
        Console.WriteLine("----------------------");

        Doctor doctor = new Doctor();
        doctor.name = "April Mae";
        doctor.DOB = "04/31/1972";
        doctor.staffID = 759;
        doctor.Qualification = "Cardiology";
        doctor.DisplayPersonInfo();
        Console.WriteLine("----------------------");

        Console.ReadLine();
    }
}

public class Person
{
    public string name { get; set; }
    public string DOB { get; set; }

    public virtual void DisplayPersonInfo()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Date of Birth: {DOB}");
    }
}

public class Patient : Person
{
    public int patientID;

    public Patient()
    {

    }

    public Patient(int pID)
    {
        patientID = pID;
    }

    public override void DisplayPersonInfo()
    {
        base.DisplayPersonInfo();
        Console.WriteLine($"Patient ID: {patientID}  ");
    }
}

public class HospitalStaff : Person
{
    public int staffID;

    public HospitalStaff()
    {

    }

    public override void DisplayPersonInfo()
    {
        base.DisplayPersonInfo();
        Console.WriteLine($"Staff ID: {staffID}  ");
    }
}

public class Admin : HospitalStaff
{
    public string reportsTo;

    public override void DisplayPersonInfo()
    {
        base.DisplayPersonInfo();
        Console.WriteLine($"Occupation: Admin");
        Console.WriteLine($"Reports To: {reportsTo}");
    }
}

public class Nurse : HospitalStaff
{
    public string shifts;

    public override void DisplayPersonInfo()
    {
        base.DisplayPersonInfo();
        Console.WriteLine($"Occupation: Nurse");
        Console.WriteLine($"Shifts: {shifts}");
    }
}

public class Doctor : HospitalStaff
{
    public string Qualification;

    public override void DisplayPersonInfo()
    {
        base.DisplayPersonInfo();
        Console.WriteLine($"Occupation: Doctor");
        Console.WriteLine($"Qualification: {Qualification}");
    }
}
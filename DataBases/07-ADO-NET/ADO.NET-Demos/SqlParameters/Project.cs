using System;

class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public override string ToString()
    {
        string text = String.Format(
            "Project(Id={0}, Name={1}, Description={2}, StartDate={3}, EndDate={4})",
            this.Id, this.Name, this.Description, this.StartDate, this.EndDate);
        return text;
    }
}

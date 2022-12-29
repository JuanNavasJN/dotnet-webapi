using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class MyTask
{
    public Guid TaskId {get;set;}
    public Guid CategoryId {get;set;}
    public string Title {get;set;}
    public string Description {get;set;}
    public Priority TaskPriority {get;set;}
    public DateTime CreatedAt {get;set;}    
    public virtual Category Category {get;set;}
    public string Resume {get;set;}
}

public enum Priority
{
    Low,
    Medium,
    High
}
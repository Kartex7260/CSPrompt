
namespace CSPrompt.Patterns.Creational;

public class FluentBuilder
{
	private readonly User user = new();

	public FluentBuilder SetName(string name) 
	{
		user.Name = name;
		return this;
	}
	public FluentBuilder SetAge(int age) 
	{
		user.Age = age;
		return this;
	}
	public FluentBuilder SetEmail(string email) 
	{
		user.Email = email;
		return this;
	}
	public FluentBuilder SetCompany(string company) 
	{
		user.Company = company;
		return this;
	}
	public FluentBuilder IsMarried 
	{
		get
		{
			user.IsMarried = true;
			return this;
		}
	}
	public User Build() => user;
}

public class User
{
	public string Name { get; set; } = "";
	public int Age { get; set; } = 0;
	public string Email { get; set; } = "";
	public string Company { get; set; } = "";
	public bool IsMarried { get; set; } = false;
}

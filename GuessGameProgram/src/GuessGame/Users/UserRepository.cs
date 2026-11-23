namespace GuessGame.Users;

public class UserRepository : IUserRepository
{
    private readonly string _file;

    public UserRepository(string file)
    {
        _file = file;
    }

    public User? FindUsername(string username)
    {
        List<User> users = GetAll();       
        foreach (var user in users)
        {
            if( user.UserName.ToLower() == username.ToLower() )
                return user;
        }
        return null;
    }

    public void Add(User user)
    {
        if(user == null) throw new ArgumentNullException(nameof(user));
        if (FindUsername(user.UserName) != null) throw new InvalidOperationException("Пользователь с таким именем уже существует.");
        string line = user.Id + ";" + user.UserName + ";" + user.Password;
        using(StreamWriter  writer = new StreamWriter(_file, true))
        {
            writer.WriteLine(line);
        }
    }

    public List<User> GetAll()
    {
        List<User> users = new List<User>();
        if(!File.Exists(_file)) return users;
        string[] lines = File.ReadAllLines(_file);
        foreach(string line in lines)
        {
            string[] parts = line.Split(";");
            if (parts.Length != 3) continue;
            if(!Guid.TryParse(parts[0], out Guid id) ) continue;
            string username = parts[1];
            string password = parts[2];
            if(string.IsNullOrWhiteSpace(username) ) continue;
            users.Add(new User(id, username, password));
        }
        return users;
    }
}

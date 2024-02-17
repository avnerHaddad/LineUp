public interface IConstraint
{
    bool RunConstraint(Shavzak shavzak);
}

public class ExampleConstraint : IConstraint
{
    public bool RunConstraint(Shavzak shavzak)
    {
        // Implement your constraint logic here
        return false;
    }
}
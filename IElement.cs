//определяет контракт
namespace OopLaba2;
public interface IElement
{
    string Describe();
    void Execute();
    List<string> GetDescriptionsSteps();
}
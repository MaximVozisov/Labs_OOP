namespace Lab13;
//класс, который хранит данные о том, какое событие произошло
public class MyLinkedListHandlerEventArgs : EventArgs
{
    public static readonly string[] ChangeTypes = new string[] { "Добавление", "Удаление", "Удаление всего", "Обновление" }; //Типы изменений
    public string CollectionName { get; private set; } //имя коллекции
    public string ChangeType { get; private set; } //тип изменений
    public object? ChangedObj { get; private set; } = null; //объект
    public object Sender { get; private set; } //объект коллекции
    public MyLinkedListHandlerEventArgs(object Sender, string CollectionName, string ChangeType, object? ChangedObj)
    {
        this.Sender = Sender;
        this.CollectionName = CollectionName;
        this.ChangeType = ChangeType;
        this.ChangedObj = ChangedObj;
    }
    public override string ToString()
    {
        return $"Объект: {ChangedObj?.ToString() ?? "NULL"} Операция: {ChangeType} Название коллекции: {CollectionName}";
    }
}
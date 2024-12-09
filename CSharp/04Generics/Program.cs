namespace _04Generics;

// See https://aka.ms/new-console-template for more information
/*
* Create a custom Stack class MyStack<T> that can be used with any data type which
has following methods
1. int Count()
2. T Pop()
3. Void Push()*/

public class MyStack<T>
{
    private T[] stackArray;
    private int count;

    public MyStack(int size = 10)
    {
        this.stackArray = new T[size];
        count = -1;
    }

    public int Count()
    {
        return count + 1;
    }

    public void Push(T item)
    {
        if (count >= stackArray.Length - 1)
        {
            Resize(stackArray.Length * 2);
        }

        count++;
        stackArray[count] = item;
    }

    public T Pop()
    {
        if (count < 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        T item = stackArray[count];
        count--;

        return item;
    }

    private void Resize(int newSize)
    {
        T[] newArray = new T[newSize];
        Array.Copy(stackArray, newArray, count + 1);
        stackArray = newArray;
    }
}

/* Create a Generic List data structure MyList<T> that can store any data type.
Implement the following methods.
1. void Add (T element)
2. T Remove (int index)
3. bool Contains (T element)
4. void Clear ()
5. void InsertAt (T element, int index)
6. void DeleteAt (int index)
7. T Find (int index)
*/
public class MyList<T>
{
    private T[] items;
    private int count;

    public MyList(int initialCapacity = 10)
    {
        items = new T[initialCapacity];
        count = 0;
    }

    public void Add(T element)
    {
        if (count >= items.Length)
        {
            Resize(items.Length * 2);
        }

        items[count] = element;
        count++;
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        T removedElement = items[index];

        for (var i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }

        count--;
        items[count] = default;

        return removedElement;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < count; i++)
        {
            if (items[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public void Clear()
    {
        Array.Clear(items, 0, count);
        count = 0;
    }

    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        if (count == items.Length)
        {
            Resize(items.Length * 2);
        }

        for (int i = count; i > index; i--)
        {
            items[i] = items[i - 1];
        }

        items[index] = element;
        count++;
    }

    public void DeleteAt(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }

        count--;
        items[count] = default;
    }

    public T Find(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        return items[index];
    }

    private void Resize(int newSize)
    {
        T[] newArray = new T[newSize];
        Array.Copy(items, newArray, count);
        items = newArray;
    }
}

/*
 * Implement a GenericRepository<T> class that implements IRepository<T> interface
that will have common /CRUD/ operations so that it can work with any data source
such as SQL Server, Oracle, In-Memory Data etc. Make sure you have a type constraint
on T were it should be of reference type and can be of type Entity which has one
property called Id. IRepository<T> should have following methods
1. void Add(T item)
2. void Remove(T item)
3. Void Save()
4. IEnumerable<T> GetAll()
5. T GetById(int id)
Explore following topics
Generics in .NET
Generic classes and methods
Collections and Data Structures
Commonly Used Collection Types
 */
public interface IEntity
{
    int Id { get; set; }
}

public interface IRepository<T> where T : class, IEntity
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

public class GenericRepository<T> : IRepository<T> where T : class, IEntity
{
    private List<T> dataSource;

    public GenericRepository()
    {
        dataSource = new List<T>(); // In-memory data source (this can be replaced by a DB context or another data source)
    }

    public void Add(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null.");
        }

        dataSource.Add(item);
    }

    public void Remove(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null.");
        }

        dataSource.Remove(item);
    }

    public void Save()
    {
        // todo - Save data to the actual data source
        Console.WriteLine("Data saved.");
    }

    public IEnumerable<T> GetAll()
    {
        return dataSource.AsReadOnly();
    }

    public T GetById(int id)
    {
        return dataSource.FirstOrDefault(x => x.Id == id);
    }
}
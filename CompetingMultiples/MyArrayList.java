
/**
 * Write a description of class MyArrayList here.
 *
 * @author (LN Shabalala)
 * @version (17 Nov 2020)
 */
import java.util.Scanner;
public class MyArrayList<E>
{
    private int size; // Number of elements in the list
    private E[] data;
    private int MAXELEMENTS = 100;
    /** Create an empty list */
    public MyArrayList() 
    {
	   data = (E[])new Object[MAXELEMENTS];// cannot create array of generics
       size = 0; // Number of elements in the list
    }
  
    public void add(int index, E e) 
    {   
    // Ensure the index is in the right range
    if (index < 0 || index > size)
      throw new IndexOutOfBoundsException
        ("Index: " + index + ", Size: " + size); 
    // Move the elements to the right after the specified index
    for (int i = size - 1; i >= index; i--)
      data[i + 1] = data[i];
    // Insert new element to data[index]
    data[index] = e;
    // Increase size by 1
    size++;
    }

    public boolean contains(Object e)
    {
    for (int i = 0; i < size; i++)
      if (e.equals(data[i])) return true;
    return false;
    }

    public E get(int index) 
    {
    if (index < 0 || index >= size)
      throw new IndexOutOfBoundsException
        ("Index: " + index + ", Size: " + size);
    return data[index];
    }
  
    public E remove(int index) 
    {
	if (index < 0 || index >= size)
           throw new IndexOutOfBoundsException
           ("Index: " + index + ", Size: " + size);
           E e = data[index];

        for (int j = index; j < size - 1; j++)
           data[j] = data[j + 1];
           data[size - 1] = null; // This element is now null
           // Decrement size
           size--;
           return e;
    }
  
    public void clear()
    {
        size = 0;
    }
 
    public void insertSorted(E param)
    {
	  int i=0; //counter in calling array
	  //two options for implementation - create new list or use add() to shift up elements - both O(n) since only 1 item is added at a time - choose add() option 
	  
	
	  if ((this.getSize()+ 1) > MAXELEMENTS)
	 	   throw new IndexOutOfBoundsException
                   ("No space for additional element");
		
	  // traverse both list until next element is larger than param or list is done
	  while (i<this.getSize() && ((Comparable)data[i]).compareTo(param) <0)
	  {
		 i++;	
	  }
	  // if list is empty this will also work to put new element in first position
	  add(i,param); // i will be equal to size if param is larger than all other elements or at correct position for new element
	  
    }		  
		  
	  
    public String toString() 
    {
       String result="[";
       for (int i = 0; i < size; i++)
      {
         result+= data[i];
         if (i < size - 1) result+=", ";
      }
      return result.toString() + "]";
    }

  
    public int getSize() 
    {
       return size;
    }
  
    public boolean sortList() 
    {
        E hold;
	for (int i = 0; i < size-1; i++)
        {
	   for (int j = 0; j<size-1; j++)
	   {  	 
	     if(((Comparable)data[j]).compareTo(data[j+1])>0)
	     {
	       hold= data[j+1];
	       data[j+1]=data[j];
	       data[j]=hold;
	     }       
	   }
       } 
       return true;	  	
    }

    public int binarySearch(E key) 
    {
       int low = 0;
       int high = size - 1;
       return binarySearch(key, low, high);
    }

    private int binarySearch( E key,int low, int high)
    {
       if (low > high)  // The list has been exhausted without a match
       return -low - 1;

      int mid = (low + high) / 2;
      if(((Comparable)key).compareTo(data[mid])<0) // if (key < data[mid])
         return binarySearch(key, low, mid - 1);
      else if(((Comparable)key).compareTo(data[mid])==0)//if (key == data[mid])
         return mid;
      else
         return binarySearch(key, mid + 1, high);
    }
    
   
    public static int computeNums()
    {
        int a, b, num;
       
        Scanner input = new Scanner(System.in);

        System.out.println("This program computes a*b, please enter a: ");
        a = input.nextInt();
        
        System.out.println("\nThis program computes a*b, please enter b: ");
        b = input.nextInt();    
             
        num = a * b;

        if (a == 0 && b == 0)
            return 0;        
        else      
            return num;            
        
    }

}


/**
 * Write a description of class TestMyArrayList here.
 *
 * @author (LN Shabalala)
 * @version (17 Nov 2020)
 */
public class TestMyArrayList
{
    public static void main(String[] args) 
    {        
        MyArrayList<Integer> list1 = new MyArrayList<>();

	
	list1.add(0,new Integer(3));
        list1.add(1,new Integer(8));
        list1.add(2,new Integer(17));
	list1.add(3,new Integer(6));
        list1.add(4,new Integer(4));
        list1.add(5,new Integer(14));
	list1.add(6,new Integer(1));
        list1.add(7,new Integer(2));
        list1.add(8,new Integer(15));
    
        System.out.println("list1 = " + list1);
	list1.sortList();
	System.out.println("list = " + list1);
	
	
        System.out.println("\n find 17 = " + list1.binarySearch(new Integer(17)));
	System.out.println("\n find 1 = " + list1.binarySearch(new Integer(1)));
	System.out.println("\n find 4 = " + list1.binarySearch(new Integer(4)));
	System.out.println("\n find 14 = " + list1.binarySearch(new Integer(14)));
	
	MyArrayList.computeNums();		
		
    }

}

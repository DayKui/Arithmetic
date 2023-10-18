using System;
using static Arithmetic.LinkArithmetic;
using System.Collections.Generic;

//https://zhuanlan.zhihu.com/p/407414826
namespace Arithmetic
{

    public struct TestData { public int num; public string des; }

    //冒泡排序 快速排序  堆排序
    class Program
    {
        static void Main(string[] args)
        {

            //List<TestData> lists = new List<TestData>();
            //lists.Add(new TestData() { num = 2 , des ="tdk"});
            //var testList = lists[0];
            //testList.num = 3;
            //testList.des = "tdkTest";

            //TestData[] array = new TestData[3];
            //array[0] = new TestData { num=2};
            //var testNum=array[0];
            //testNum.num = 3;
            //testNum.des = "tdkTest";
            //Console.WriteLine($"array={array[0]}");

            //ArrayArithmetic arrayArith = new ArrayArithmetic();
            //int[,] result = arrayArith.螺旋矩阵(4);

            //var length = arrayArith.滑动窗口1(7, new int[] { 2, 3, 1, 2, 4, 3 });
            //Console.ReadLine(); 

            //var nums = arrayArith.有序数组平方(new int[] { -4, -1, 0, 3, 10 });
            //Console.ReadLine();


            //LinkArithmetic link = new LinkArithmetic();
            //var changeNode=link.交换链表();
            //var node1 = link.RmvListNode(2);
            //var node2 = link.RmvListNode2(2);
            //bool exist= link.环形列表以及入口位置(out var node);
            //ListNode meetNode = link.相交链表();


            //var revNode=link.反转链表();

            //var stackAndQueue = new StackAndQueue();
            //bool valid= stackAndQueue.判断是否有效括号("(()]");
            //valid = stackAndQueue.判断是否有效括号("([])");
            //var num= stackAndQueue.逆波兰表达式求值(new string [] { "2","1","+","3","*" });

            //MyQueue myQue = new MyQueue();
            //var res= myQue.单调队列();

            //快速排序 quick = new 快速排序();
            //int[] a = { 5, 4, 9, 8, 7, 6, 0, 1, 3, 2 };
            //quick.QuickSort(a, 0, a.Length - 1);
            //foreach (var item in a)
            //{
            //    Console.WriteLine($"quick sort=>{item}");
            //}

            //StructTest structTest = new StructTest();
            //structTest.Test();

            插入排序 insert = new 插入排序();
            int[] a = { 38, 65, 97, 76, 13, 27, 49 };
            insert.InsertSort(a);
            foreach (var item in a)
            {
                Console.WriteLine($"insert sort=>{item}");
            }

        }

    }

    public class StructTest 
    {
        public struct TestStruct 
        {
            public int a;
            public int b;
        }

        public TestStruct[] arrayTest =new TestStruct[] { new TestStruct { a = 1, b = 2 }, new TestStruct { a = 2, b = 3 } };
        public List<TestStruct>  listTest= new List<TestStruct>() { new TestStruct { a = 1, b = 2 }, new TestStruct { a = 2, b = 3 } };

        public void Test() 
        {
          
            arrayTest[0].a = 100;
            foreach (var item in arrayTest)
            {
                Console.WriteLine($"array {item.a},{item.b}");
            }
           
        }
    }


    //https://blog.csdn.net/enternalstar/article/details/106932822?spm=1001.2101.3001.6650.3&utm_medium=distribute.pc_relevant.none-task-blog-2%7Edefault%7EBlogCommendFromBaidu%7ERate-3-106932822-blog-132288303.235%5Ev38%5Epc_relevant_default_base&depth_1-utm_source=distribute.pc_relevant.none-task-blog-2%7Edefault%7EBlogCommendFromBaidu%7ERate-3-106932822-blog-132288303.235%5Ev38%5Epc_relevant_default_base&utm_relevant_index=4
    public class 快速排序 
    {

        public void QuickSort(int [] array, int low, int high)
        {

            if (low >= high)
            {
                return;
            }
            // 基准值 选取当前数组第一个值
            int temp = array[low];
            // 低位i从左向右扫描
            int i = low;
            // 高位j从右向左扫描
            int j = high;
            while (i < j)
            {
                while (i < j && array[j] >= temp)
                {
                    j--;
                }
                if (i < j)
                {
                    array[i] = array[j];
                    i++;
                }
                while (i < j && array[i] < temp)
                {
                    i++;
                }
                if (i < j)
                {
                    array[j] = array[i];
                    j--;
                }
            }
            array[i] = temp;
            // 左边的继续递归排序
            QuickSort(array, low, i - 1);
            // 右边的继续递归排序
            QuickSort(array, i + 1, high);
        }
    }

    public class 插入排序
    {

        public void InsertSort(int[] array)
        {

            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i];
                int j = i;
                if (temp<array[j-1])
                {
                    while (j>0 && temp<array[j-1])
                    {

                        array[j] = array[j - 1];
                        j--;
                    }
                    array[j] = temp;
                }

            }
        }
    }
    //数组 线性连续的数据集合

    public class ArrayArithmetic
    {

        public int 移除数组中相同元素返回最终长度(int[] nums, int val)
        {
            // 初始化快慢指针
            int fast = 0;
            int slow = 0;
            for (; fast < nums.Length; fast++)
            {
                if (nums[fast] != val)
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
            }
            return slow;
        }


        //https://mp.weixin.qq.com/s?__biz=MzI0NjAxMDU5NA==&mid=2475922670&idx=1&sn=c07f56c74d859a7a9d934e3c36488cb9&chksm=ff22f363c8557a75f2e036cb1e0f4bce6fee53ad1ee0012f1ac689703316e88a18c7bd6d49c1&token=1145569493&lang=zh_CN#rd
        public int[,] 螺旋矩阵(int n)
        {
            int left = 0, right = n - 1, up = 0, down = n - 1;
            int[,] res = new int[n, n];
            int cnt = 1;
            while (cnt < n * n)
            {
                for (int i = left; i <= right; i++)
                {
                    res[up, i] = cnt++;
                }
                up++;

                for (int i = up; i <= down; i++)
                {
                    res[i, right] = cnt++;
                }
                right--;

                for (int i = right; i >= left; i--)
                {
                    res[down, i] = cnt++;
                }
                down--;

                for (int i = down; i >= up; i--)
                {
                    res[i, left] = cnt++;
                }
                left++;
            }
            return res;
        }

        //https://mp.weixin.qq.com/s?__biz=MzI0NjAxMDU5NA==&mid=2475922559&idx=1&sn=77426b06f94e712acba06df275cde853&chksm=ff22f3f2c8557ae4fa6104b346e55d46974f635cb9b58a846125f5dd8644eaad53adfba40d6b&token=1145569493&lang=zh_CN#rd
        public int 滑动窗口1(int target, int[] nums)
        {
            int left = 0, sum = 0, result = int.MaxValue;
            for (int right = 0; right < nums.Length; right++)
            {
                sum += nums[right];
                while (sum >= target)
                {
                    result = Math.Min(result, right - left + 1);
                    sum -= nums[left++];
                }
            }
            return result == int.MaxValue ? 0 : result;
        }


        //https://mp.weixin.qq.com/s?__biz=MzI0NjAxMDU5NA==&mid=2475922258&idx=1&sn=95bfe3da6211191d5335cb520820bc99&chksm=ff22f4dfc8557dc9eca2d93ed8b28e4e01c8557ed7e239b6b0265ac7d13ea50d44ab310637c2&token=1145569493&lang=zh_CN#rd
        public int[] 有序数组平方(int[] nums)
        {
            int right = nums.Length - 1;
            int left = 0;
            int[] res = new int[nums.Length];
            int index = nums.Length - 1;
            while (left <= right)
            {
                if (nums[left] * nums[left] > nums[right] * nums[right])
                {
                    res[index--] = nums[left] * nums[left];
                    ++left;
                }
                else
                {
                    res[index--] = nums[right] * nums[right];
                    --right;
                }
            }
            return res;

        }
    }

    //https://mp.weixin.qq.com/s?__biz=MzI0NjAxMDU5NA==&mid=2475918898&idx=1&sn=e5c7bf9c43dd205082f77beead41a187&chksm=ff22e1bfc85568a945b3e4569ea727148e6e736ccce15ec12d77c2f8ae7b8acb2eabf900e3a6&token=1996171232&lang=zh_CN#rd

    //链表 线性非连续数据集合可以连续也可以不连续 由不同节点组成的线性数据结构，节点之间通过地址相连
    //每个结点分为两部分：数据域和指针域。数据域存储的数据，指针域存储着同一个表里下一个节点的位置。
    //单链表：如果链表中的每个节点只包含一个指针域，这个链表就叫做单链表。单链表的指针域指向的是下一个节点的地址，我们把指向下个节点地址的指针叫做后继指针。
    //头指针:《链表的第一个结点的指针》
    //头节点：《是放在第一个元素的节点之前，它的数据域一般没有意义，并且它本身也不是链表必须要带的。
    //它的设立是单纯是为了操作的统一和方便，其实就是为了在某些时候可以更方便的对链表进行操作，
    //有了头结点，我们在对第一个元素前插入或者删除结点的时候，它的操作与其它结点的操作就统一了》。

    //双向链表：《顾名思义，两个方向向的链表。相比起单链表来说，它多了一个前驱指针 prev，指向前驱节点。
    //这样双向链表既可以往前走，也可以往后走》。

    public class LinkArithmetic
    {
        public class ListNode
        {
            public int num;
            public ListNode next;
        }

        public ListNode headNode;
        public LinkArithmetic()
        {
            headNode = new ListNode() { num = 1 };
            headNode.next = new ListNode() { num = 2 };
            headNode.next.next = new ListNode() { num = 3 };
            headNode.next.next.next = new ListNode() { num = 4 };
            headNode.next.next.next.next = new ListNode() { num = 5 };
        }

        //删除倒数第n个结点 (普通方法)
        public ListNode RmvListNode(int n)
        {
            ListNode pre = headNode;
            int last = GetLinkLength(pre) - n;
            if (last<=0) //如果last小于等于0表示删除的是头结点
                return pre.next;
            //这里首先要找到要删除链表的前一个结点
            for (int i = 0; i < last-1; i++)
            {
                pre = pre.next;
            }
            pre.next = pre.next.next;
            return headNode;
        }


        //删除倒数第n个结点 (双指针方法)
        public ListNode RmvListNode2(int n)
        {
            ListNode slow = headNode;
            ListNode fast = headNode;

            for (int i = 0; i < n; i++)
            {
                fast = fast.next;
            }
            //如果fast为空，表示删除的是头结点
            if (fast == null)
                return headNode.next;

            while (fast.next!=null)//当快指针到达表尾时，慢指针正好到达倒数第n位
            {
                slow = slow.next;
                fast = fast.next;
            }
            //这里最终slow不是倒数第n个节点，他是倒数第n+1个节点，
            //他的下一个结点是倒数第n个节点,所以删除的是他的下一个结点
            slow.next = slow.next.next;
            return headNode;
        }

        //两两交换链表相邻节点的值，返回交换后的链表。
        //https://mp.weixin.qq.com/s?__biz=MzI0NjAxMDU5NA==&mid=2475919380&idx=1&sn=f4564f6926b169e8f7820ade0d04af8f&chksm=ff22ef99c855668fe740cd03b4987eb0e11a33385e4813a03525a53712adcf51d121c7129235&token=1029130343&lang=zh_CN#rd
        public ListNode 交换链表()
        {
            if (headNode == null || headNode.next == null)
                return headNode;
            var dummyNode = new ListNode() { num = 0 };
            dummyNode.next = headNode;
            var pre = dummyNode;
            var p = dummyNode.next;
            while (p.next != null)
            {
                var q = p.next;
                pre.next = q;
                p.next = q.next;
                q.next = p;

                pre = p;
                p = p.next;
            }
            return dummyNode.next;
        }

        //https://mp.weixin.qq.com/s?__biz=MzI0NjAxMDU5NA==&mid=2475919611&idx=1&sn=cebf6321b9d87cd7b2eb94e7c1bc8bb2&chksm=ff22ef76c8556660b42516720fbb7a5c946d419eddf88056bd77f6036d7f191c63fec6a683e1&token=1029130343&lang=zh_CN#rd
        public bool 环形列表以及入口位置(out ListNode enterNode)
        {
            enterNode = null;
            var circleLinkHead = new ListNode() { num = 1 };
            circleLinkHead.next = new ListNode() { num = 2 };
            circleLinkHead.next.next = new ListNode() { num = 3 };
            circleLinkHead.next.next.next = new ListNode() { num = 4 };
            circleLinkHead.next.next.next.next = new ListNode() { num = 5 };
            circleLinkHead.next.next.next.next = circleLinkHead.next.next;//环形入口在num=3的结点处

            //判断是都有环以及入口
            var fast = circleLinkHead;
            var slow = circleLinkHead;
            while (fast?.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)//有环
                {
                    var index1 = fast;
                    var index2 = circleLinkHead;
                    while (index1 != index2)
                    {
                        index1 = index1.next;
                        index2 = index2.next;
                    }
                    enterNode = index1;
                    return true;
                }
            }
            return false;
        }

        public ListNode 相交链表()
        {
            var circleLinkHead1 = new ListNode() { num = 1 };
            circleLinkHead1.next = new ListNode() { num = 2 };
            circleLinkHead1.next.next = new ListNode() { num = 3 };
            circleLinkHead1.next.next.next = new ListNode() { num = 4 };
            circleLinkHead1.next.next.next.next = new ListNode() { num = 5 };

            var circleLinkHead2 = new ListNode() { num = 100 };
            circleLinkHead2.next = new ListNode() { num = 101 };
            circleLinkHead2.next.next = circleLinkHead1.next.next;
            circleLinkHead2.next.next.next = circleLinkHead1.next.next.next;
            circleLinkHead2.next.next.next.next = new ListNode() { num = 5 };
            var lenA = GetLinkLength(circleLinkHead1);
            var lenB = GetLinkLength(circleLinkHead2);

            var curA = circleLinkHead1;
            var curB = circleLinkHead2;
            if (lenB > lenA)
            {
                var tmpLength = lenB;
                lenB = lenA;
                lenA = tmpLength;

                var temNode = curB;
                curB = curA;
                curA = temNode;
            }
            int gap = lenA - lenB;
            while (gap-- >0)
            {
                curA = curA.next;
            }

            while (curA!=null)
            {
                if (curA==curB)
                {
                    return curA;
                }
                curA = curA.next;
                curB = curB.next;
            }
            return null;
        }


        public ListNode 反转链表()
        {
            var circleLinkHead1 = new ListNode() { num = 1 };
            circleLinkHead1.next = new ListNode() { num = 2 };
            circleLinkHead1.next.next = new ListNode() { num = 3 };
            circleLinkHead1.next.next.next = new ListNode() { num = 4 };
            circleLinkHead1.next.next.next.next = new ListNode() { num = 5 };

            var p = circleLinkHead1;
            ListNode q = null;
            while (p!=null)
            {
                var temp = p.next;
                p.next = q;
                q = p;
                p = temp;
            }
            return q;
        }

        private int GetLinkLength(ListNode head) 
        {
            if (head==null)
                return 0;
            int length = 0;
            var curNode = head;
            while (curNode != null)
            {
                length++;
                curNode = curNode.next;
            }
            return length;
        }
    }

    //栈和队列
    public class StackAndQueue
    {

        //https://mp.weixin.qq.com/s?__biz=MzI0NjAxMDU5NA==&mid=2475920000&idx=1&sn=4d94d8c1fc33e43940a253c50f130252&chksm=ff22ed0dc855641baf002c72356fe58beb233e9dd9ff01875deab483728c2ebd5bf73f353e89&token=1029130343&lang=zh_CN#rd
        public bool 判断是否有效括号(string s)
        {
            Stack<char> stack = new Stack<char>();
            char ch;
            for (int i = 0; i < s.Length; i++)
            {
                ch = s[i];
                if (ch == '(')
                    stack.Push(')');
                else if (ch == '{')
                    stack.Push('}');
                else if (ch == '[')
                    stack.Push(']');
                else if (stack.Count <= 0 || stack.Peek() != ch)
                    return false;
                else
                    stack.Pop();

            }
            return stack.Count <= 0;
        }

        //逆波兰表达式又叫后缀表达式，是将运算符写在操作数之后。
        public int 逆波兰表达式求值(String[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            int n = tokens.Length;
            for (int i = 0; i < n; i++)
            {
                string token = tokens[i];
                if (int.TryParse(token, out int num))
                {
                    stack.Push(num);
                }
                else
                {
                    int num2 = stack.Pop();
                    int num1 = stack.Pop();
                    switch (token)
                    {
                        case "+":
                            stack.Push(num1 + num2);
                            break;
                        case "-":
                            stack.Push(num1 - num2);
                            break;
                        case "*":
                            stack.Push(num1 * num2);
                            break;
                        case "/":
                            stack.Push(num1 / num2);
                            break;
                        default:
                            break;
                    }
                }
            }
            return stack.Pop();
        }

        //https://mp.weixin.qq.com/s?__biz=MzI0NjAxMDU5NA==&mid=2475920459&idx=1&sn=3f7a5d2c9d01d2d0b7e7aba0cf3140d7&chksm=ff22ebc6c85562d0726fbfeccf6e987b4d5b379e50942c981e7075a710eca10af38806833047&token=469543786&lang=zh_CN#rd
        //public int[] 滑动窗口最大值(int[] nums, int k)
        //{
        //    if (nums==null ||nums.Length<=1)
        //    {
        //        return nums;
        //    }
        //    int[] result = new int[nums.Length - k + 1];
        //    int count = 0;
        //}

      
    }

    class MyQueue
    {
        //https://mp.weixin.qq.com/s?__biz=MzI0NjAxMDU5NA==&mid=2475920459&idx=1&sn=3f7a5d2c9d01d2d0b7e7aba0cf3140d7&chksm=ff22ebc6c85562d0726fbfeccf6e987b4d5b379e50942c981e7075a710eca10af38806833047&token=469543786&lang=zh_CN#rd
        public int[] 单调队列()
        {
            int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
            int k = 3;
            if (nums == null || nums.Length < 2) return nums;
            // 双端队列 保存当前窗口最大值的数组位置 保证队列中数组位置的数值按从大到小排序
            LinkedList<int> linkList = new LinkedList<int>();
            // 结果数组
            int[] result = new int[nums.Length - k + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                // 保证从大到小 如果前面数小则需要依次弹出，直至满足要求
                while (linkList.Count > 0 && nums[linkList.Last.Value] <= nums[i])
                {
                    linkList.RemoveLast();
                }
                // 添加当前值对应的数组下标
                linkList.AddLast(i);
                // 判断当前队列中队首的值是否有效
                if (linkList.First.Value <= i - k)
                {
                    linkList.RemoveFirst();
                }
                // 当窗口长度为k时 保存当前窗口中最大值
                if (i + 1 >= k)
                {
                    result[i + 1 - k] = nums[linkList.First.Value];
                }
            }
            return result;
        }
    }
}

def last4Upper(str: String): String = {
    str.take(str.length() - 4) + str.drop(str.length() - 4).toUpperCase()
   }

 def sumSubstring(str1: String, str2: String, text: String) = {
    str1 + ": " + (text.split(str1, -1 ).length - 1) + " times appears in text" + "\n" + str2 + ": " + (text.split(str2, -1 ).length - 1)+ " times appears in text"
  }

def minSubarray(n: Int, array: List[Int]): Int = {
    if (n > array.size) {
      return -1;
    }

    
    var subArray = array.take(n)
    var minSum = array.take(n).sum
    
    for( i <- 1 to array.size-n) {
      val curSum = array.slice(i, i + n).sum
      if (curSum < minSum ){
        minSum = curSum
        subArray = array.slice(i, i + n)
      }
    }
    minSum
  }



println(last4Upper("one two three"))
println(last4Upper("cat"))
println(minSubarray(3, List(2,5,8,1,1,2,4)))
println(sumSubstring("aaa", "dde", "aaabgdccdaaaddwsdde"))
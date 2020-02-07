# Min Matching Algorithm


## Description

There will be two types of stacks which contains order of "Bids(Buyers)" and "Offers(Sellers)". Each order has 2 types of parameter.

1. All or None: Which means order should be either fulfilled full or no order. In short partial trading should not happen.
2. Range: Which contains minimum ticket size meaning each trade should contain amount greater than or equal to minimum ticket size.

There are total 4 kinds of order.
1. Simple Order: Can be Partially Traded
2. All or None: Either fulfilled full or no order
3. Range: Which contains minimum ticket size
4. Both: Which have both All or None and Range.

## Pseudocode

This program does the trading between buyers and sellers given two stacks.

```

function isCompatibleGivesTrade(remaining_amount, starting_index,sellers, buyer,buyer_index,buyers) {

  if(remaining_amount=0)
    return true
    
  else if(remaining_amount < buyer`s range or starting_index > sellers`s count || buyer_index > buyer`s count)
    return false
  
  if(sellers[starting_index]`s qunatity <= 0 or sellers[starting_index] is in Recursion)
    return (remaining_amount, starting_index+1,sellers, buyer,buyer_index,buyers)
    
  Check for below 16 conditions:
  
  ------------------------------------------------------------------------------------------------------------------------------------------------
  |               | Simple Order        | All or None                           | Range(min ticket size)          | Both                          |
  ------------------------------------------------------------------------------------------------------------------------------------------------
  | Simple Order  | Do Trade            | trade which is lesser                 | trade which is lesser           | Do trade if qunatity          |
  |               |                     | perform appropriate actions           | perform appropriate actions     | greater than range            |
  ------------------------------------------------------------------------------------------------------------------------------------------------
  | All or None   | Trade if amount     | If left is greater than check for     | Trade if amount greater than    | Trade Appropriate amount      |
  |               | lesser or recursion | remaing in next or check for right    | min size and do allocate        | Do allocate                   |
  ------------------------------------------------------------------------------------------------------------------------------------------------
  | Range         | Trade of qunatity   | if quantity is greater than left than | Check both range and trade min  | If min tickt size satisfies   |
  |               | greater than range  | do trade                              | amount                          | Do trade                      |
  ------------------------------------------------------------------------------------------------------------------------------------------------
  | Both          | Trade if all/none   | Do trade if all or none satisfies     | If both amount greater than     | Perform appropriate action    |
  |               | and range satisfies |                                       | min ticket size on both sides   | Do Allocate                   |
  -------------------------------------------------------------------------------------------------------------------------------------------------


}

function loopThrough(buyers, sellers) {

    for each buyer in buyers
    
        Call isCompatibleGivesTrade(buyerQuantity,0,sellers,buyer,buyer_index,buyers)
        
    endfor
}

function Main() { 

In the main function 
     
         
   Take the buyer orders from the user 
   Take the seller orders from the user 
  
   send both stack to loopThrough function
   
   print buyers and sellers
} 

```

## Approach

Dynamic Programming

## Testcases

File named as Tescases inside home directory in this repository.

#! /bin/bash 


function add
{
  let sum=$1+$2
  echo "Sum = $sum"
}


function subtract
{
  let sum=$1-$2
  echo "diffrence = $sum"
}

function multiply
{
  let mul=$1*$2
 echo "Product = $mul"

}

function divide
{
 let div=$1/$2
 echo "Division result = $div"

}



bool=true

while $bool 
do
	read -p "Enter two number on which mathematical operation has to be performed : " num1 num2
	echo " Enter Id of Operation that you want to perform on inputed values"
	echo " a. addition "
	echo " b. substraction "
	echo " c. Multiplication "
	echo " d. Division "

	read option

	case $option in
		a) add $num1 $num2
			;;
		b) subtract $num1 $num2
			;;
		c) multiply $num1 $num2
			;;
		d) divide $num1 $num2
			;;
		*) exit ;;
		
	esac

done



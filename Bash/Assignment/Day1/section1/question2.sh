#! /bin/bash 

read -p "Enter the number for which sum of digit has to be calculated : " num


sum=0

while [[ $num -gt 0 ]]
do
	let sum=sum+num%10
	let num=num/10
done

echo "Sum of all digits is : $sum "


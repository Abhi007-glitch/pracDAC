#! /bin/bash
read -p "Enter String to be checked for Palindrom : " input
reverse=""



for (( i = 0 ; i<${#input} ; i++ ))
do     
	temp=${input:i:1}
	reverse="$temp$reverse"
	
done
 

if [[ "$reverse" == "$input" ]]
then
	echo " String $reverse is a Palindrom "
else 
	echo " String is not a Palindrom "
fi



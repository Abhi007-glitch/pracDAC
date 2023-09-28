#!  /bin/bash

read -p "Enter three numbers among which greatest has to be find : " num1 num2 num3


greatest=num1

if [[ $greatest -lt $num2 ]];
then
     greatest=$num2
fi

if [[ $greatest -lt $num3 ]];
then 
	greatest=$num3
fi

echo "The Greatest number is $greatest "


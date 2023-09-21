
#! /bin/bash


PrintPyramid(){
read -p "Enter the size of pyramid : " size

echo " " 
tabs=$size-1

for (( i=1 ; i<=$size ; i++ ))
do 
	for (( j=0 ; j<$tabs ; j++ ))
	do
		echo -n " "
	done
	let tabs=tabs-1
	for (( j=1 ; j<=i ; j++ )) 
	do
		echo -n "$i "
	done

	echo " "
	echo " "
done

echo " " 
echo " "

}

function pattern2 {
read -p "Enter the size of Pattern2 : " size

echo " "
for (( i=1 ; i<=$size ; i++ ))
do
	for (( j=1 ; j<=$i ; j++ ))
	do
		echo -n "$i"
	done
	echo " "
done

echo " "
echo " "

}

function PrintStair {

read -p "Enter the size of stair : " size

echo " " 
for (( i=1 ; i<=$size ; i++ ))
do
	for (( j=1 ; j<$i ; j++ ))
	do
		echo -n "|  "
	done
	echo "|__"
done

echo " "
echo " " 

}


bool=true
while $bool
do
	echo " Select one of the following options Id to run "
        echo " 1. Print Pyramid "
	echo " 2. Print Stairs "
	echo " 3. Print Pattern1  :   " 
        read option	
	 
   
# *************** function call does not require $  **********************

	case $option in 
		1) PrintPyramid ;;
		2) PrintStair ;;
		3) pattern2 ;;
	        4) bool=false ;;
	        *)exit ;;
	esac
done	




#! /bin/bash
#input syntx -> cp -i <Source_File_Path> <Destination_File_path>
Destination_File_path=$4
Source_File_path=$3
if [[ $2 == "-I"  ]];
then
	if [[ -e "$($Destination_File_path)" ]];
	then
		data=$(cat $Destination_File_path)
		length=${#data}
		if [[ $(length) -gt 0 ]];
		then
			read -p "Do you really want to overwrite Data of this file,Enter Y to procced : " option
		        if [[ $option == "Y" ]] || [[ $option == "y" ]];
			then
			    cp $Source_File_path $Destination_File_path
			else 
				exit
			fi
		else 
	            cp $Source_File_path $Destination_File_path
		fi
	else 
		echo "Creating new File and copying data to it "
		cp $Source_File_path $Destination_File_path
	fi
fi





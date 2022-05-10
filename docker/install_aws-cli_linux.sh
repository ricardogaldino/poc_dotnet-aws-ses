#!/bin/bash
sudo apt update
sudo apt install python3-pip
source ~/.profile
curl "https://awscli.amazonaws.com/awscli-exe-linux-x86_64.zip" -o "awscliv2.zip"
sudo apt install unzip
unzip awscliv2.zip
sudo ./aws/install -i /usr/local/aws-cli -b /usr/local/bin
source ~/.profile
sudo rm -Rf aws
sudo rm -Rf awscliv2.zip
pip install awscli-local
source ~/.profile

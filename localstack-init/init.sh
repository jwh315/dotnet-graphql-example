#!/usr/bin/env bash

echo "Creating Dynamodb Table"
aws dynamodb create-table --table-name Listings --attribute-definitions AttributeName=ListingId,AttributeType=S --key-schema AttributeName=ListingId,KeyType=HASH --provisioned-throughput ReadCapacityUnits=1,WriteCapacityUnits=1 --endpoint-url http://localhost:4566 --region "us-east-1"
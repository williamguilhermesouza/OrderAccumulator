#!/bin/bash

sleep 30s

/opt/mssql-tools/bin/sqlcmd -U sa -P A&VeryComplex123Password -Q "CREATE DATABASE IF NOT EXISTS DB_OrderAccumulator"
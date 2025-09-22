# Customer Code Generator

A small C# console application that generates a unique code when you enter a customer number.

## What it does
- Prompts for a customer number (or accepts it as a CLI argument).
- Produces a deterministic, human-readable unique code for that customer (e.g. `C-20250922-00123` or `CUST-000123-XYZ`).
- Intended as a lightweight local generator for IDs (no external services).

## Features
- CLI interactive and non-interactive modes.
- Easy to customise the code format (prefix, date, zero-padded number, suffix).
- Safe to add to other projects (no database required).

## Quick start

 Clone the repo:
   ```bash
   git clone https://github.com/yourname/CustomerCodeGenerator.git
   cd CustomerCodeGenerator

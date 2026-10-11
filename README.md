# Entropy

A console utility for generating cryptographically strong passwords.

> Entropy is a measure of unpredictability. A password is exactly as good as it is random.

---

## Features

- **Cryptographic strength.** Passwords are generated with `RandomNumberGenerator` from `System.Security.Cryptography`.
- **Flexible character sets.** Lowercase and uppercase letters, digits, and special characters can each be excluded individually.
- **Two launch modes:**
  - **with arguments** — the password is printed immediately, no questions asked;
  - **interactive** — a step-by-step dialog where options are chosen with the keyboard.
- **No third-party dependencies.** Only the .NET standard library is used.

---

## Quick start

### Requirements

Building and running requires the [.NET 10.0 SDK](https://dotnet.microsoft.com/download).

### Build and run

Clone the repository and go to the project folder:

```bash
git clone https://github.com/demurel0/entropy.git
cd entropy
```

---

## Usage

### Running with arguments

You can pass just the length, or combine it with flags that exclude character sets:

```bash
dotnet run --project src/Entropy -- [length] [options]
```

#### Available options

| Flag | Description | Default |
| :--- | :--- | :--- |
| `--length <number>` | Password length | 16 |
| `-l, --no-lower` | Exclude lowercase letters | Included |
| `-u, --no-upper` | Exclude uppercase letters | Included |
| `-d, --no-digits` | Exclude digits | Included |
| `-s, --no-special` | Exclude special characters | Included |
| `-h, --help` | Show usage help | - |

### Interactive mode

If you run the utility without arguments, a step-by-step setup wizard opens. The **Enter** key automatically selects the option highlighted with a capital letter:

```bash
dotnet run --project src/Entropy
```

---

## Examples

### Generating with arguments

```console
$ dotnet run --project src/Entropy -- 20
Generated password: Q8f!mV2#tR9&xL4$wZ1p

$ dotnet run --project src/Entropy -- 12 -s
Generated password: k7Qx2mPzR9dL

$ dotnet run --project src/Entropy -- --length 24 -d -s
Generated password: vQmTzLkPaRxWbNcYdFgHjKeS

$ dotnet run --project src/Entropy -- 16 -l -u
Generated password: 4-7(2)*9%1^3&_0#
```

### Errors on invalid arguments

```console
$ dotnet run --project src/Entropy -- 100
Length must be between 8 and 64.

$ dotnet run --project src/Entropy -- -l -u -d -s
You cannot exclude all character sets at the same time.

$ dotnet run --project src/Entropy -- --length
The '--length' flag must be followed by a number.

$ dotnet run --project src/Entropy -- --unknown
Unknown argument: '--unknown'. Use '-h' or '--help' for help.
```

### Interactive dialog

```console
$ dotnet run --project src/Entropy
← → length  |  Y/n answer  |  Enter confirm  |  Q quit

How long should the password be? 12
Include lowercase letters? Y
Include uppercase letters? n
Include digits? n
Include special characters? y

Generated password: -@x-xd(r#o(h
```

Quit at any step with Q:

```console
$ dotnet run --project src/Entropy
← → length  |  Y/n answer  |  Enter confirm  |  Q quit

How long should the password be? 16
Include lowercase letters? Y
Include uppercase letters?
Cancelled.
```

If you disable lowercase letters, uppercase letters, and digits:

```console
$ dotnet run --project src/Entropy
← → length  |  Y/n answer  |  Enter confirm  |  Q quit

How long should the password be? 16
Include lowercase letters? n
Include uppercase letters? n
Include digits? n
Only special characters remain.

Generated password: @#%^(*)-=_+!$&-^
```

### Help

```console
$ dotnet run --project src/Entropy -- -h
┌──────────────────────┐
│  ••••••••••          │
└──────────────────────┘

USAGE
  Entropy [length] [options]

OPTIONS
  --length <number>  Password length
  -l, --no-lower     Exclude lowercase letters
  -u, --no-upper     Exclude uppercase letters
  -d, --no-digits    Exclude digits
  -s, --no-special   Exclude special characters
  -h, --help         Show this help
```

---

## License

Distributed under the [MIT](LICENSE) license.

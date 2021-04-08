# Default install.
linkerd install | kubectl apply -f -


# Install Linkerd into a non-default namespace.
linkerd install -l linkerdtest | kubectl apply -f -

# Installation may also be broken up into two stages by user privilege, via
# subcommands.

# The installation can be configured by using the --set, --values, --set-string and --set-file flags.
# A full list of configurable values can be found at https://www.github.com/linkerd/linkerd2/tree/main/charts/linkerd2/README.md

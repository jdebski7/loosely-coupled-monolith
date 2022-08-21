case $1 in
  "graphql")
    DLL="ApiGateway.GraphQL/ApiGateway.GraphQL.dll"
    ;;

  *)
    echo "Usage: $0 graphql"
    exit 1
    ;;
esac

shift

# forward SIGTERM to child process
trap 'kill -TERM $PID' TERM

dotnet $DLL $@ &
PID=$!

wait $PID
trap - TERM
wait $PID
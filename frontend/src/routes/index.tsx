import { createFileRoute } from "@tanstack/react-router"
import { Base } from "#/common/layouts/base"

export const Route = createFileRoute("/")({
  component: Index,
})

function Index() {
  return (
    <Base>
      <p>- خالی -</p>
    </Base>
  )
}

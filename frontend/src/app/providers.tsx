import type { PropsWithChildren } from "react"
import { TanStackQueryProvider } from "#/common/lib/tanstack-query"

export const Providers = ({ children }: PropsWithChildren) => (
  <TanStackQueryProvider>{children}</TanStackQueryProvider>
)
